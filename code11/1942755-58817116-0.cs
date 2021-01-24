                List<string> sublist1 = new List<string>() { "a", "b" };   
                List<string> sublist2 = new List<string>() { "a", "b" };   
                List<string> sublist3 = new List<string>() { "a", "c" };   
                List<List<string>> listOfLists = new List<List<string>> { sublist1, sublist2, sublist3 };    
                Dictionary<string, int> counterDictionary = new Dictionary<string, int>();                  
                    foreach (List<string> strList in listOfLists)       
                    {   
                        string concat = strList.Aggregate((s1, s2) => s1 + ", " + s2);   
                        if (!counterDictionary.ContainsKey(concat))   
                            counterDictionary.Add(concat, 1);   
                        else   
                            counterDictionary[concat] = counterDictionary[concat] + 1;   
                    }   
                    foreach (KeyValuePair<string, int> keyValue in counterDictionary)   
                    {   
                           Console.WriteLine(keyValue.Key + "=>" + keyValue.Value);   
                    }   
