    var subject = new List<string>
    {                            
    "test",
    "last"
    }.ToObservable();
    var my = subject
                .Where(x => x == "last").Take(1)
                .Merge(subject.TakeWhile(x => x != "last"));
    my.Subscribe(
        o => Console.WriteLine("On Next: " + o), 
        () => Console.WriteLine("Completed"));
    Console.ReadLine();
