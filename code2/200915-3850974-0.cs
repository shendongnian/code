    public class MultiValueDictionary<KeyType, ValueType> : Dictionary<KeyType, List<ValueType>>
    {
        /// <summary>
        /// Hide the regular Dictionary Add method
        /// </summary>
        new private void Add(KeyType key, List<ValueType> value)
        {            
            base.Add(key, value);
        }
        /// <summary>
        /// Adds the specified value to the multi value dictionary.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add. The value can be null for reference types.</param>
        public void Add(KeyType key, ValueType value)
        {
            //add the value to the dictionary under the key
            MultiValueDictionaryExtensions.Add(this, key, value);
        }
    }
    public static class MultiValueDictionaryExtensions
    {
        /// <summary>
        /// Adds the specified value to the multi value dictionary.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add. The value can be null for reference types.</param>
        public static void Add<KeyType, ListType, ValueType>(this Dictionary<KeyType, ListType> thisDictionary, 
                                                             KeyType key, ValueType value)
        where ListType : IList<ValueType>, new()
        {
            //if the dictionary doesn't contain the key, make a new list under the key
            if (!thisDictionary.ContainsKey(key))
            {
                thisDictionary.Add(key, new ListType());
            }
            //add the value to the list at the key index
            thisDictionary[key].Add(value);
        }
    }
