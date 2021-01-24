    class Program
        {
            static void Main(string[] args)
            {
                Dictionary<string, int> names = new Dictionary<string,int>();
    
    
                for (int i = 0; i < 10; i++)
                {
                    names.Add(String.Format("name{0}", i.ToString()), i);
                }
    
                var xx1 = names["name1"];
                var xx2 = names["name2"];
                var xx3 = names["name3"];
            }
        }
