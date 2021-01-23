    TimeSpan t = new TimeSpan(0,0,5); //5 Second Expiry
    ExpiringDictionary<int, string> dictionary 
        = new ExpiringDictionary<int,string>(t);
    dictionary.Add(1, "Alice");
    dictionary.Add(2, "Bob");
    dictionary.Add(3, "Charlie");
    //dictionary.Add(1, "Alice"); //<<this will throw a exception as normal... 
    System.Threading.Thread.Sleep(6000);
    dictionary.Add(1, "Alice"); //<< this however should work fine as 6 seconds have passed
