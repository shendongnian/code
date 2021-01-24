    public class Test
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }
    var dict1 = new Dictionary<string, Test>
    {
        { "Key1", new Test { Number = 0, Name = "Name1" } },
        { "Key2", new Test { Number = 0, Name = "Name2" } },
        { "Key3", new Test { Number = 0, Name = "Name3" } }
    };
    var dict2 = new Dictionary<string, Test>
    {
        { "Key1", new Test { Number = 0, Name = "Name1" } },
        { "Key4", new Test { Number = 0, Name = "Name4" } }
    };
    // Put the dictionaries you want to combine into one list: 
    var all = new List<Dictionary<string, Test>>();
    all.Add(dict1);
    all.Add(dict2);
    // Declare result dictionary
    var combine = new Dictionary<string, Test>();
    
