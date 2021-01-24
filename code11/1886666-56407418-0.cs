    using System.Linq;
    ...
    var withinSpecs = arr.Where(e => e.GetSomeValue() >= 1 && e.GetSomeValue() < 5).ToArray();
    if(withinSpecs.Length == 0)
    {
        Console.WriteLine("No data");
    }
    else
    {
        foreach(var element in withinSpecs)
            Console.WriteLine(element);
    }
