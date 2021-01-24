    private static void ShowCollectionInformation(object coll)
        {
            switch (coll)
            {
                case Array arr:
                   Console.WriteLine($"An array with {arr.Length} elements.");
                   break;
                case IEnumerable<int> ieInt:
                   Console.WriteLine($"Average: {ieInt.Average(s => s)}");
                   break;   
                case IList list:
                   Console.WriteLine($"{list.Count} items");
                   break;
                case IEnumerable ie:
                   string result = "";
                   foreach (var e in ie) 
                      result += "${e} ";
                   Console.WriteLine(result);
                   break;   
                case null:
                   // Do nothing for a null.
                   break;
                default:
                   Console.WriteLine($"A instance of type {coll.GetType().Name}");
                   break;   
            }
        }
