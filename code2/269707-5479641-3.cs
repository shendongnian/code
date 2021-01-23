    var list = Enumerable.Range(0, 10);
    Func<int, bool> condition = i => i != 5;
    int needed = 1;
    var query = list.Select(item => new
                    {
                        item,
                        count = condition(item)
                            ? needed
                            : needed--
                    })
                    .Where(x => x.count > 0)
                    .Select(x => x.item)
                    .ToList(); // this might cause problems
    if (needed != 0)
        throw new InvalidOperationException("Sequence is not properly terminated");
