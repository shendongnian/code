     foreach (var group in groups)
     {
         foreach (var item in group)
         {
             string label = !string.IsNullOrEmpty(item.Section)
                          ? item.Section
                          : item.Label;
             Console.WriteLine("{0,-8} | {1}", label, item.Data);
         }
         Console.WriteLine("-------------");
     }
