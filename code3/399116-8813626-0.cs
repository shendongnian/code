     clsCallProcess cls = new clsCallProcess(index, url, name, timer);
     thSystem[index] = new Thread(new ThreadStart(
        () =>
        cls.StartProcess(result => Console.WriteLine (result))));
     // ---------------------------^
     // If you want to do something other than write it to the console, do that here. 
     thSystem[index].Start();
