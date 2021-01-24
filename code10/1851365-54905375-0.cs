    var wordsToFind = new List<string>{ "tes","don"};
    var data= new List<ObjectA>()
    {
        new ObjectA()
        {
            StringList = new List<string>{"test", "done", "blah"}
        },
        new ObjectA()
        {
            StringList = new List<string>{"test2", "done2", "blah2"}
        }
    };
    
    var result = new List<string>();
    foreach (var item in data.Select(x=>x.StringList))
    {
        var foo = wordsToFind.Where(x => wordsToFind.Contains(x)).ToList();
        result.AddRange(foo);
    }
