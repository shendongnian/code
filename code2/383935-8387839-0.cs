    [Serializable]
    public class CustomDictionary: ISerializable
    {
        /// <summary>
        /// Inner object.
        /// </summary>        
        private Dictionary<string, string> innerDictionary;
    
        public CustomDictionary()
        {
            innerDictionary = new Dictionary<string, string>();
        }
        public CustomDictionary(IDictionary<string, string> dictionary)
        {
            innerDictionary = new Dictionary<string, string>(dictionary);
        }
    
        public Dictionary<string, string> InnerDictionary
        {
            get { return this.innerDictionary; }
        }
        
        //Used when deserializing
        protected CustomDictionary(SerializationInfo info, StreamingContext context)
        {
            if (object.ReferenceEquals(info, null)) throw new ArgumentNullException("info");
            innerDictionary = new Dictionary<string, string>();
            foreach (SerializationEntry entry in info)
            {
                innerDictionary.Add(entry.Name, entry.Value as string);
            }
        }
        
        //Used when serializing
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (!object.ReferenceEquals(info, null))
            {
                foreach (string key in innerDictionary.Keys)
                {
                    string value = innerDictionary[key];
                    info.AddValue(key, value);
                }
            }
        }
        
        //Add methods calling InnerDictionary as necessary (ContainsKey, Add, etc...)
    }
