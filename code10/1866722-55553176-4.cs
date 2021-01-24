         public void Print<T>(List<T> list)
                {
                    foreach (var itemList in list)
                    {
                            var properties=typeof(T).GetProperties();
                            var values=properties.Select(x=>x.GetValue(itemList));
                            Console.WriteLine(string.Join(",",values));
                    }
                }
        
