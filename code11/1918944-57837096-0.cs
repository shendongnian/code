     public void sortDictionaryByName()
        {
            //GOAL: Get all the values from the dictionary into a list that can use the 
              .sort method
            ArrayList sortedNames = new ArrayList();
            foreach (KeyValuePair<uint, Subreddit> value in subredditsDictionary)
            {
                sortedNames.Add(value.Value.name.ToString());
            }
            sortedNames.Sort();
            foreach (var value in sortedNames)
            {
                foreach (KeyValuePair<uint, Subreddit> key in subredditsDictionary)
                {
                    if (value.ToString() == key.Value.name.ToString())
                    {
                        Subreddit tempData = new Subreddit
                        {
                            subID = key.Key,
                            name = key.Value.name,
                            members = key.Value.members,
                            active = key.Value.active
                        };
                        sortedDictionary.Add(tempData.subID, tempData);
                    }
                }
            }
        }
