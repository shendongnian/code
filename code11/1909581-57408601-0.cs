    // Say these are your objects - may have more properties
    public class Obj1
    {
        public string Name {get; set;}
        public int Id {get; set;}
        public Obj1(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
	
    // Create some instances
    Obj1 objA = new MyObject("Foo", 1);
    Obj1 objB = new MyObject("Bar", 2);
    Obj1 objC = new MyObject("Goo", 3);
    // Your test class that contains the custom object, and a list
    public class Test
    { 
        public Obj1 obj1;
        public List<string> items;
        public Test(Obj1 myobject, List<string> myItems)
        {
            obj1 = myobject;
            items = myItems;
        }
    }
    // Make a list of test objects
    List<Test> tests = new List<Test>{
        new Test(objA, new List<string>{"a", "b", "c"}),
        new Test(objB, new List<string>{"d", "e", "f"}),
        new Test(objC, new List<string>{"g", "h", "i"})};
    // Query to create a list of new anonymous objects with select properties of Obj1
    // and (for example) the first element of the list 
    IEnumerable<dynamic> results = tests
        .Select(o => new { Name = o.obj1.Name, 
                           ID = o.obj1.Id, 
                           Item = o.items.ElementAt(0) ?? null} )
        .ToList();
    Console.WriteLine(results.ElementAt(0));
    Console.WriteLine(results.ElementAt(1));
    Console.WriteLine(results.ElementAt(2));
    //  { Name = Foo, ID = 1, Item = a }
    //  { Name = Bar, ID = 2, Item = d }
    //  { Name = Goo, ID = 3, Item = g }
