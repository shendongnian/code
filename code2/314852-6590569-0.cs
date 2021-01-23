    using (var context = new MyContext())
    {
        var master = context.Masters.Find(1);
    
        context.Entry(master)
            .Collection(m => m.Details)
            .Query()
            .Where(d => d.Type == 1)
            .Load();
    
        //do stuff with master
    
    }
