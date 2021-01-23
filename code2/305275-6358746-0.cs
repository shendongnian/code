    //FileName: ListboxMenuItems.cs
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Bail
    {
        public class ListboxMenuItem
        {
            public String FirstName { get; set; }
            public String LastName { get; set; }
            public String Address { get; set; }
    
            public ListboxMenuItem(String firstName, String lastName, String address)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Address = address;
            }
        }
    
        public class ListboxMenuItems : IEnumerable, IEnumerator
        {
            List<ListboxMenuItem> Items { get; set; }
    
            private int _position = -1;
            public ListboxMenuItems()
            {
                Items = new List<ListboxMenuItem>();
                Items.Add(new ListboxMenuItem("Michael", "Anderberg", "12 North Third Street, Apartment 45"));
                Items.Add(new ListboxMenuItem("Chris", "Ashton", "34 West Fifth Street, Apartment 67"));
                Items.Add(new ListboxMenuItem("Cassie", "Hicks", "56 East Seventh Street, Apartment 89"));
                Items.Add(new ListboxMenuItem("Guido", "Pica", "78 South Ninth Street, Apartment 10"));
            }
    
            #region Implementation of IEnumerable
    
            /// <summary>
            /// Returns an enumerator that iterates through a collection.
            /// </summary>
            /// <returns>
            /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
            /// </returns>
            /// <filterpriority>2</filterpriority>
            public IEnumerator GetEnumerator()
            {
                return this;
            }
    
            #endregion
    
            #region Implementation of IEnumerator
    
            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>
            /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
            /// </returns>
            /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception><filterpriority>2</filterpriority>
            public bool MoveNext()
            {
                _position++;
                return (_position < Items.Count);
            }
    
            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception><filterpriority>2</filterpriority>
            public void Reset()
            {
                _position = -1;
            }
    
            /// <summary>
            /// Gets the current element in the collection.
            /// </summary>
            /// <returns>
            /// The current element in the collection.
            /// </returns>
            /// <exception cref="T:System.InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element.</exception><filterpriority>2</filterpriority>
            public object Current
            {
                get
                {
                    try
                    {
                        return Items.ElementAt(_position);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
    
            #endregion
        }
    }
