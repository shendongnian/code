    public class Generic
        {
            public void Print<T>(List<T> list)
            {
                if(list is List<Student>)
                {
                    var studentList = list as List<Student>;
                    foreach (var itemList in studentList)
                    {
                        Console.WriteLine(itemList.Id);
                    }
                }
                else if(list is List<Product>)
                {
                    var productList = list as List<Product>;
                    foreach(var itemList in productList)
                    {
                        Console.WriteLine(itemList.Price);
                    }
                }
            }
        }
