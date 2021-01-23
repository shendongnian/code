    public CustomerClass(){
      List<string> tempList  = new List<string>() { "string1", "string2" };
      someReadOnlyList = ArrayList.Synchronized(tempList);
    }
    public void Run()
    {
        var groupedData = DataReader.GetSourceData().AsEnumerable().GroupBy(n => n.Field<int>("ID"));
        Parallel.ForEach<IGrouping<int, DataRow>, CustomerDataContext>(
            groupedData,
            () => new CustomerDataContext(),
            (g, _, ctx) =>
            {
                var inter = FindOrCreateInteraction(ctx, g.Key);
                inter.ID = g.Key;
                inter.Title = g.First().Field<string>("Title");
                CalculateSomeProperty(ref inter);
                return ctx;
            },
            ctx => ctx.SubmitAllChanges());
    }
    private Interaction FindOrCreateInteraction(CustomerDataContext ctx, int ID)
    {
        var query = ctx.Interactions.Where(n => n.Id = ID);
        if (query.Any())
        {
            return query.Single();
        }
        else
        {
            var inter = new Interaction();
            ctx.InsertOnSubmit(inter);
            return inter;
        }
    }
    private void CalculateSomeProperty(ref Interaction inter)
    {
        Console.Writeline(someReadOnlyList[0]);
        //do some other stuff
    }
}
