        var singleCollection = list.FirstOrDefault();
        singleCollection.Numbers = list.SelectMany(c => c.Numbers).ToList() ;
        Console.WriteLine(singleCollection.Numbers.ElementAt(0));
        var singleCollection2 = list.FirstOrDefault();
        singleCollection2.Numbers.Concat(list.SelectMany(c => c.Numbers)); 
        Console.WriteLine(singleCollection2.Numbers.ElementAt(0));
