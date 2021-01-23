    using (var context = new MyContext())
    {
        var list = new List<MyClass>();
        for (int i = 0; i < 1000; i++)
        {
            var m = new MyClass()
            {
                Id = i+1,
                P1 = "Some text ....................................",
                // ... initialize P2 to P49, all with the same text
                P50 = "Some text ...................................."
            }
            list.Add(m);
        }
        Stopwatch watch = new Stopwatch();
        watch.Start();
        foreach (var entity in list)
        {
            context.Set<MyClass>().Attach(entity);
            context.Entry(entity).State = System.Data.EntityState.Modified;
        }
        watch.Stop();
        long time = watch.ElapsedMilliseconds;
    }
