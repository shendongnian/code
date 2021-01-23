    //--------------------------------------------------------------------------
    // 
    //  Copyright (c) Microsoft Corporation.  All rights reserved. 
    // 
    //  File: ObservableConcurrentDictionary.cs
    //
    //--------------------------------------------------------------------------
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Threading;
    using System.Diagnostics;
    namespace System.Collections.Concurrent
    {
        /// <summary>
        /// Provides a thread-safe dictionary for use with data binding.
        /// </summary>
        /// <typeparam name="TKey">Specifies the type of the keys in this collection.</typeparam>
        /// <typeparam name="TValue">Specifies the type of the values in this collection.</typeparam>
        [DebuggerDisplay("Count={Count}")]
        public class ObservableConcurrentDictionary<TKey, TValue> :
            ICollection<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>,
            INotifyCollectionChanged, INotifyPropertyChanged
        {
            private readonly SynchronizationContext _context;
            private readonly ConcurrentDictionary<TKey, TValue> _dictionary;
            /// <summary>
            /// Initializes an instance of the ObservableConcurrentDictionary class.
            /// </summary>
            public ObservableConcurrentDictionary()
            {
                _context = AsyncOperationManager.SynchronizationContext;
                _dictionary = new ConcurrentDictionary<TKey, TValue>();
            }
            /// <summary>Event raised when the collection changes.</summary>
            public event NotifyCollectionChangedEventHandler CollectionChanged;
            /// <summary>Event raised when a property on the collection changes.</summary>
            public event PropertyChangedEventHandler PropertyChanged;
            /// <summary>
            /// Notifies observers of CollectionChanged or PropertyChanged of an update to the dictionary.
            /// </summary>
            private void NotifyObserversOfChange()
            {
                var collectionHandler = CollectionChanged;
                var propertyHandler = PropertyChanged;
                if (collectionHandler != null || propertyHandler != null)
                {
                    _context.Send(s =>
                    {
                        collectionHandler?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                        propertyHandler?.Invoke(this, new PropertyChangedEventArgs("Count"));
                        propertyHandler?.Invoke(this, new PropertyChangedEventArgs("Keys"));
                        propertyHandler?.Invoke(this, new PropertyChangedEventArgs("Values"));
                    }, null);
                }
            }
            /// <summary>
            /// Notifies observers of CollectionChanged or PropertyChanged of an update to the dictionary.
            /// </summary>
            /// <param name="actionType">Add or Update action</param>
            /// <param name="changedItem">The item involved with the change</param>
            private void NotifyObserversOfChange(NotifyCollectionChangedAction actionType, object changedItem)
            {
                var collectionHandler = CollectionChanged;
                var propertyHandler = PropertyChanged;
                if (collectionHandler != null || propertyHandler != null)
                {
                    _context.Send(s =>
                    {
                        collectionHandler?.Invoke(this, new NotifyCollectionChangedEventArgs(actionType, changedItem));
                        propertyHandler?.Invoke(this, new PropertyChangedEventArgs("Count"));
                        propertyHandler?.Invoke(this, new PropertyChangedEventArgs("Keys"));
                        propertyHandler?.Invoke(this, new PropertyChangedEventArgs("Values"));
                    }, null);
                }
            }
            /// <summary>
            /// Notifies observers of CollectionChanged or PropertyChanged of an update to the dictionary.
            /// </summary>
            /// <param name="actionType">Remove action or optionally an Add action</param>
            /// <param name="item">The item in question</param>
            /// <param name="index">The position of the item in the collection</param>
            private void NotifyObserversOfChange(NotifyCollectionChangedAction actionType, object item, int index)
            {
                var collectionHandler = CollectionChanged;
                var propertyHandler = PropertyChanged;
                if (collectionHandler != null || propertyHandler != null)
                {
                    _context.Send(s =>
                    {
                        collectionHandler?.Invoke(this, new NotifyCollectionChangedEventArgs(actionType, item, index));
                        propertyHandler?.Invoke(this, new PropertyChangedEventArgs("Count"));
                        propertyHandler?.Invoke(this, new PropertyChangedEventArgs("Keys"));
                        propertyHandler?.Invoke(this, new PropertyChangedEventArgs("Values"));
                    }, null);
                }
            }
            /// <summary>Attempts to add an item to the dictionary, notifying observers of any changes.</summary>
            /// <param name="item">The item to be added.</param>
            /// <returns>Whether the add was successful.</returns>
            private bool TryAddWithNotification(KeyValuePair<TKey, TValue> item)
                => TryAddWithNotification(item.Key, item.Value);
            /// <summary>Attempts to add an item to the dictionary, notifying observers of any changes.</summary>
            /// <param name="key">The key of the item to be added.</param>
            /// <param name="value">The value of the item to be added.</param>
            /// <returns>Whether the add was successful.</returns>
            private bool TryAddWithNotification(TKey key, TValue value)
            {
                bool result = _dictionary.TryAdd(key, value);
                int index = IndexOf(key);
                if (result) NotifyObserversOfChange(NotifyCollectionChangedAction.Add, value, index);
                return result;
            }
            /// <summary>Attempts to remove an item from the dictionary, notifying observers of any changes.</summary>
            /// <param name="key">The key of the item to be removed.</param>
            /// <param name="value">The value of the item removed.</param>
            /// <returns>Whether the removal was successful.</returns>
            private bool TryRemoveWithNotification(TKey key, out TValue value)
            {
                int index = IndexOf(key);
                bool result = _dictionary.TryRemove(key, out value);
                if (result) NotifyObserversOfChange(NotifyCollectionChangedAction.Remove, value, index);
                return result;
            }
            /// <summary>Attempts to add or update an item in the dictionary, notifying observers of any changes.</summary>
            /// <param name="key">The key of the item to be updated.</param>
            /// <param name="value">The new value to set for the item.</param>
            /// <returns>Whether the update was successful.</returns>
            private void UpdateWithNotification(TKey key, TValue value)
            {
                _dictionary[key] = value;
                NotifyObserversOfChange(NotifyCollectionChangedAction.Replace, value);
            }
            /// <summary>
            /// WPF requires that the reported index for Add/Remove events are correct/reliable. With a dictionary there
            /// is no choice but to brute-force search through the key list. Ugly.
            /// </summary>
            private int IndexOf(TKey key)
            {
                var keys = _dictionary.Keys;
                int index = -1;
                foreach(TKey k in keys)
                {
                    index++;
                    if (k.Equals(key)) return index;
                }
                return -1;
            }
            // ICollection<KeyValuePair<TKey,TValue>> Members
            void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
                => TryAddWithNotification(item);
            void ICollection<KeyValuePair<TKey, TValue>>.Clear()
            {
                _dictionary.Clear();
                NotifyObserversOfChange();
            }
            bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
                => ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).Contains(item);
            void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
                => ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).CopyTo(array, arrayIndex);
            int ICollection<KeyValuePair<TKey, TValue>>.Count
            {
                get => _dictionary.Count;
            }
            bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
            {
                get => ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).IsReadOnly;
            }
            bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
                => TryRemoveWithNotification(item.Key, out TValue temp);
            // IEnumerable<KeyValuePair<TKey,TValue>> Members
            IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
                => _dictionary.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator()
                => _dictionary.GetEnumerator();
            // IDictionary<TKey,TValue> Members
            public void Add(TKey key, TValue value)
                => TryAddWithNotification(key, value);
            public bool ContainsKey(TKey key)
                => _dictionary.ContainsKey(key);
            public ICollection<TKey> Keys
            {
                get { return _dictionary.Keys; }
            }
            public bool Remove(TKey key)
                => TryRemoveWithNotification(key, out TValue temp);
            public bool TryGetValue(TKey key, out TValue value)
                => _dictionary.TryGetValue(key, out value);
            public ICollection<TValue> Values
            {
                get => _dictionary.Values;
            }
            public TValue this[TKey key]
            {
                get => _dictionary[key];
                set => UpdateWithNotification(key, value);
            }
        }
    }
