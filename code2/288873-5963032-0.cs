    List<Dictionary<int, string>> a = new List<Dictionary<int, string>>();
    
                Dictionary<int,string> b = new Dictionary<int,string>();
    
                b.Add(1, "Anwer");
                
    
                a.Add(b);
    
                for (int i = 0; i < a.Count; i++)
                    foreach (KeyValuePair<int, string> v in a[i])
                        Console.WriteLine(v.Key + " ------ " + v.Value);
