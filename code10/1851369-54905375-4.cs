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
      
    var result = (from item in data.Select(x => x.StringList)
                  from bar in item
                  from word in wordsToFind
                  where bar.Contains(word)
                  select bar)
                  .ToList();
