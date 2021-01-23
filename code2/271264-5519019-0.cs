    string[] days = new string[] { "DAY1", "DAY2", "DAY3", "DAY4", "DAY5", "DAY6", "DAY7" };
    
                List<string> res = new List<string>();
                res.Add(string.Empty);
    
                int Leadtime = 7;
                
                for (int i = 1; i <= Leadtime; i++)
                {
                    res.Add(string.Empty);
                    int tmp = i + Leadtime - 1;
    
                    for (int x = i; x <= tmp; x++)
                    {
                        if (x > Leadtime) { x = 1; tmp = i-1; }
                        res[i] += " " + days[x-1];
                    }
    
                }
    
                foreach (string s in res)
                {
                    Console.WriteLine(s);
                }
    
                Console.ReadKey();
