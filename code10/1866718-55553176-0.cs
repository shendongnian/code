    public class Generic
        {
            public void Print(List<object> list)
            {
                foreach (var itemList in list)
                {
                    
                        var properties=itemList.GetType().GetProperties().Select(x=>x.Name);
                        Console.WriteLine(string.Join(",",properties);
                    
                    
                }
            }
        }
