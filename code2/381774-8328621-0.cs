    var pi = typeof(DateTime).GetProperty("Now");
    
    var result = pi.PropertyType.GetInterface("INotifiyPropertyChanged");
    
    Console.WriteLine(result != null);
