    var list = Enumerable.Range(0, 10);
    Func<int, bool> condition = i => i != 5;
    int needed = 1;
    var query = list.Where(item => condition(item)
                                       ? needed > 0
                                       : needed-- > 0)
                    .ToList(); // this might cause problems
    if (needed != 0)
        throw new InvalidOperationException("Sequence is not properly terminated");
