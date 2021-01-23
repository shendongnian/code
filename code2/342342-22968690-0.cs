    public class Widget
    {
        public string Name { get; set; }
    }
    
    var widgets1 = new[]
    {
        new Widget { Name = "Red", },
        new Widget { Name = "Green", },
        new Widget { Name = "Blue", },
        new Widget { Name = "Black", },
    };
    
    // adding ToList() will result in 'static' query result but
    // updates to the objects will still affect the source objects
    var query1 = widgets1
        .Where(i => i.Name.StartsWith("B"))
        //.ToList()
        ;
    
    foreach (var widget in query1)
    {
        widget.Name = "Yellow";
    }
    
    // produces no output unless you uncomment out the ToList() above
    // query1 is reevaluated and filters out "yellow" which does not start with "B"
    foreach (var name in query1)
        Console.WriteLine(name.Name);
    
    // produces Red, Green, Yellow, Yellow
    // the underlying widgets were updated
    foreach (var name in widgets1)
        Console.WriteLine(name.Name);
