    private class Entry {
     public string Message { get; set;}
     public string Title { get; set;}
     public DateTime Date { get; set;}
    }
    
    ...
    //your code converted to use this `Entry` object rather than a `string[]`
    
    List<Entry> msgBoard = new List<Entry>();
    
    Entry info = new Entry();    
    
    Console.WriteLine("\tTitle: ");    
    string title = Console.ReadLine();    
    info.Title = title;    
    
    Console.WriteLine("\tMessage: ");    
    string msg = Console.ReadLine();    
    info.Message = msg;    
    
    string date = DateTime.Now;    
    info.Date = date;    
    
    loggBok.Add(logg);
    loggBok.Sort(new Comparison<Entry>((Entry x, Entry y) => x.Date.CompareTo(y.Date)));
