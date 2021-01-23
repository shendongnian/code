            Hashtable clientList = new Hashtable();
            foreach (DictionaryEntry dictionaryEntry in clientList)
            {
                // work with value.
                Debug.Print(dictionaryEntry.Value.ToString());
                // work with key.
                Debug.Print(dictionaryEntry.Key.ToString());
            }
