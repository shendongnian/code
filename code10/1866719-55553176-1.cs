         public void Print(List<object> list)
                {
                    foreach (var itemList in list)
                    {
                        
                            var properties=itemList.GetType().GetProperties();
                            var values=properties.Select(x=>x.GetValue(itemList));
                            Console.WriteLine(string.Join(",",values);
                        
                        
                    }
                }
        
