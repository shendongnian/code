    Func<ExcusesDataContext, string> commonResult = CompiledQuery.Compile(
        (ExcusesDataContext c) => c.Excuses.GroupBy(m => m.Reason).OrderByDescending(m => m.Count()).Select(m => m.Key).FirstOrDefault()
    );
    
    Console.WriteLine(commonResult(new ExcusesDataContext()));
    Console.ReadLine();
