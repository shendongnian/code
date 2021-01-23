    var groups = items.GroupBy(item => item.ListId);
    foreach(var group in groups)
    {
         Console.WriteLine("List with ID == {0}", group.Key);
         foreach(var item in group)
            Console.WriteLine("    Item: {0}", item.ItemName);
    }
