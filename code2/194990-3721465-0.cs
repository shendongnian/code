    List<string> zomglist = new List<string>(); 
    for (int i = 1; i < 10; i++) 
    { 
          int arraypos = disk + (i * totaldisks); 
          zomglist.Add(linearray[arraypos].ToString()); 
          Console.WriteLine("zomglist data: {0}", zomglist.Last()); 
    }
    lollist.Add(zomglist); 
