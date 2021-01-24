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
    var lists = data.Select(x => x.StringList);
    foreach (var item in lists)
    {
            foreach (var bar in item)
            {
                foreach (var word in wordsToFind)
                {
                    if (bar.Contains(word))
                        result.Add(bar);
                }
            }              
    }
