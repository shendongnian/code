    Dictionary<string, string> names = new Dictionary<string, string>();
    names.Add("Saeed", "Neamati");
    names.Add("Rasour", "Zabihi");
    names.Add("Vahid", "Asefi");
    names.Add("Mohsen", "Parmooz");
    
    var query = from name in names
                select name.Key.StartsWith("V") ? name.Key : name.Value;
    query.ToList().ForEach(n => {
        Console.WriteLine(n);
    });
    Console.ReadLine();
