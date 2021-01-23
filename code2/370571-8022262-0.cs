                for (int i = 0; i < keys.Length; i += 2)
                {
                    string titleKey = keys[i];
                    string messageKey = keys[i+1];
                    string titleVal = values.Get(titleKey);
                    string messageVal = values.Get(messageKey);
                    result.Add(titleVal, messageVal);
                }
