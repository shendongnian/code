            foreach(var a in allCollection)
            {
                if (!selectedCollection.Any(s => a.Name == s.Name))
                {
                    selectedCollection.Add(new BasicClass {Name =a.Name, Age=a.Age});     
                }
            }
