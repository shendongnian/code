    var itemsAlreadyAdded = new int[] { 2, 4, 6 };
    var newIds = new string[] { "2", "3" };
    
    var itemsToAdd = newIds.Except(itemsAlreadyAdded.Select(iaa => iaa.ToString()));
                
    foreach (var item in itemsToAdd)
    {
        Console.WriteLine(item);
    }
    
    Console.ReadLine();
