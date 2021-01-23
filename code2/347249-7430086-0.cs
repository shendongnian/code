            foreach (object key in dictionary.Keys)
            {
                if (dictionary[key] == resourceItem)
                {
                    return key.ToString();
                }
            }
            return null;
        }
