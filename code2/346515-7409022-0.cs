            Dictionary<string, List<int>> Origin = new Dictionary<string, List<int>>();
            Origin["toto"] = new List<int>(){1,2,3};
            Origin["tata"] = new List<int>();
            Origin["titi"] = new List<int>(){1,2};
            Dictionary<string, List<int>> Changes = new Dictionary<string,List<int>>();
            Changes["toto"] = new List<int>() { 1, 2, 3, 4 };
            Changes["tata"] = new List<int>(){1};
            Changes["titi"] = new List<int>() { 2 };
            Dictionary<string, List<int>> ToRemove = new Dictionary<string, List<int>>();
            Dictionary<string, List<int>> ToAdd = new Dictionary<string, List<int>>();
            foreach (string key in Origin.Keys)
            {
                ToRemove[key] = Origin[key];
                ToAdd[key] = Changes[key];
                
                foreach (int i in ToRemove[key])
                {
                    
                    if (ToAdd[key].Contains(i)) //There is no change
                    {
                        ToAdd[key].Remove(i);
                        ToRemove[key].Remove(i);
                    }
                }
            }
