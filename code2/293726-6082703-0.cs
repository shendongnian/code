    int index = input.IndexOf('?');
    var query = input.Substring(index + 1)
                     .Split('&')
                     .SingleOrDefault(s => s.StartsWith("q="));
                     
    if (query != null)
        Console.WriteLine(query.Substring(2));
