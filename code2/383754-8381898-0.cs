    foreach (var group in list.GroupBy(i => i[0]))
    {
       Console.WriteLine("Section: " + group.Key);
       foreach (var elt in group)
       {
          Console.WriteLine(elt);
       }
    }
