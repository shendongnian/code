    [Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        static SerializableDictionary()
        {
            AssertSerializable(typeof(TKey));
            AssertSerializable(typeof(TValue));
        }
    
        static void AssertSerializable(Type t)
        {
            if (!t.IsSerializable)
            {
                throw new NotSupportedException(string.Format(
                    "{0} is not serializable", t.Name));
            }
        }
    }
