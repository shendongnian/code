     public class program
    {
        
        public static void Main()
        {
      SortedDictionary<int, string> Min1 = new SortedDictionary<int, string>();
      SortedDictionary<int, string> Min2 = new SortedDictionary<int, string>();
      SortedDictionary<int, string> Min3 = new SortedDictionary<int, string>();
      SortedDictionary<int, string> Min4 = new SortedDictionary<int, string>();
      SortedDictionary<int, string> Min5 = new SortedDictionary<int, string>();
          Min1.Add(3, "name");
          Min2.Add(1, "hello");
          Min3.Add(5, "marco");
          Min4.Add(4, "is");
          Min5.Add(2, "my");
     List<SortedDictionary<int, string>> list = new List<SortedDictionary<int, string>>();
            list.Add(Min1);
            list.Add(Min2);
            list.Add(Min3);
            list.Add(Min4);
            list.Add(Min5);
          
            List<SortedDictionary<int, string>> final_list = new List<SortedDictionary<int, string>>();
            List<int> index = new List<int>() ;
            foreach (var element in list)
            {
                foreach (var elements in element)
                {
                    index.Add(elements.Key);
                    Console.Write(" " +elements.Value+ " ");
                }
            }
            index.Sort();
            
            foreach (var indexelement in index)
            {
                foreach (var element in list)
                {
                    foreach (var elements in element)
                    {
                        if (indexelement == elements.Key)
                        {
                            final_list.Add(element);
                        }
                    }
                }
            }
            Console.WriteLine();
            foreach (var element in final_list)
            {
                foreach (var elements in element)
                {
                    Console.Write(" " + elements.Value+ " ");
                }
            }
            Console.ReadLine();
        }
    }
