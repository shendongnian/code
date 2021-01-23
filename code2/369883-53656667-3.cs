    //Assuming holder class above making 'holds' object
    public (int Id, string Name) ReturnNamedTuple(int id, string name) => (id, name);
    public static List<(int Id, string Name)> ReturnNamedTuplesFromHolder(List<Hold> holds) => holds.Select(x => (x.Id, x.Name)).ToList();
    public static void DoSomethingWithNamedTuplesInput(List<(int id, string name)> inputs) => inputs.ForEach(x => Console.WriteLine($"Doing work with {x.id} for {x.name}"));
    var namedTuples2 = holds.Select(x => ReturnNamedTuple(x.Id, x.Name));
    var namedTuples3 = ReturnNamedTuplesFromHolder(holds);
    DoSomethingWithNamedTuplesInput(namedTuples.ToList());
