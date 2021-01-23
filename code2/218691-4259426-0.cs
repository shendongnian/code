    Console.WriteLine("Updating Blocks\n===============");
    var blocksToUpdate = LinqtoSqlDBDataContext.Blocks.Where(b => b.Color == null).ToArray();
    foreach( var block in blocksToUpdate )
    {
     // do something...
    }
