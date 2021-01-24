    var bytes = File.ReadAllBytes(@"Path to your csv file");    
    List<Topic> list = GetAll(bytes);
    //Print list item to console
    foreach (var item in list)
    {
        Console.WriteLine($"ID: {item.Id}\t Description: {item.Description}\t DecimalPTS: {item.DecimalPts}");
    }
    
