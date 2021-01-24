     class Program
        {
            abstract class Buildable
            {
                public string Name { get; set; } = string.Empty;
            }
    
            class Home : Buildable
            {
    
            }
    
            class Roard: Buildable
            {
    
            }
    
            static void Main(string[] args)
            {
                List<Type> listTypes = new List<Type>()
                {
                    typeof(Home),
                };
    
                List<Buildable> listBuildable = new List<Buildable>()
                {
                    new Home(){Name = "home 1"},
                    new Home(){Name = "home 2"},
                    new Home(){Name = "home 3"},
                    new Roard(){Name = "road 1"},
                    new Roard(){Name = "road 2"},
                    new Roard(){Name = "road 3"},
                };
                foreach(var item in listBuildable)
                {
                    var itemType = item.GetType();
                    Console.WriteLine("Buildable name = " + item.Name);
                    Console.Write("item typeof" + itemType.ToString());
    
                    if (listTypes.Find(o => o.Equals(itemType)) != null)
                        Console.WriteLine(" - Type isset in list");
                    else
                        Console.WriteLine(" - Unknown type");
    
                    Console.WriteLine();
    
                }
                Console.ReadLine();
            }
        }
