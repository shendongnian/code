    public interface IMultiDictionary<TKey, TValue> :
      IDictionary<TKey, ICollection<TValue>>,
      IDictionary,
      ICollection<KeyValuePair<TKey, TValue>>,
      IEnumerable<KeyValuePair<TKey, TValue>>,
      IEnumerable {
      /// <summary>Adds a value into the dictionary</summary>
      /// <param name="key">Key the value will be stored under</param>
      /// <param name="value">Value that will be stored under the key</param>
      void Add(TKey key, TValue value);
      /// <summary>Determines the number of values stored under a key</summary>
      /// <param name="key">Key whose values will be counted</param>
      /// <returns>The number of values stored under the specified key</returns>
      int CountValues(TKey key);
      /// <summary>
      ///   Removes the item with the specified key and value from the dictionary
      /// </summary>
      /// <param name="key">Key of the item that will be removed</param>
      /// <param name="value">Value of the item that will be removed</param>
      /// <returns>True if the item was found and removed</returns>
      bool Remove(TKey key, TValue value);
      /// <summary>Removes all items of a key from the dictionary</summary>
      /// <param name="key">Key of the items that will be removed</param>
      /// <returns>The number of items that have been removed</returns>
      int RemoveKey(TKey key);
    }
