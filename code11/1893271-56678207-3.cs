    void LoopThruLinkedList(params LinkedList<string>[] strLists)
    {
       var results = strLists
                    .SelectMany(inner => inner.Select((item, index) => new { item, index }))
                    .GroupBy(i => i.index, i => i.item)
                    .Select(g => g.ToList());
    
       foreach (var list in results)
       {
          foreach (var item in list)
             Console.Write($"{item,-20}");
          Console.WriteLine();
       }
    }
