        protected override SharedResourceDictionary<T, K> Deserialize(IntermediateReader input,
                                                                 ContentSerializerAttribute format,
                                                                 SharedResourceDictionary<T, K> existingInstance)
        {
            if (existingInstance == null)
                existingInstance = new SharedResourceDictionary<T, K>();
            
            while (input.MoveToElement(Itemformat.ElementName))
            {
                T key;
    
                input.Xml.ReadToDescendant(Keyformat.ElementName);
                key = input.ReadObject<T>(Keyformat);
                input.Xml.ReadToNextSibling(Valueformat.ElementName);
                input.ReadSharedResource<K>(Valueformat, (K value) =>
                {
                    existingInstance.Add(key, value);
                });
                input.Xml.ReadEndElement();
            }
    
            return existingInstance;
        }
    }
