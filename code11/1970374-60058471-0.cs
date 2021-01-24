    {
                var result = new List<string[]>();
    
                string[] column1 = { "jim west", "Le tomo", "Sara brown" };
                string[] column2 = { "aaa", "bbb" };
                string[] column3 = { "12345" };
    
                foreach(string c1 in column1)
                {
                    for(int i = 0; i < column2.Length; i++)
                    {
                        string[] toAdd = { c1, column2[i], column3.Length> i ? column3[i] : ""  };
                        result.Add(toAdd);
                    }
                }
 
