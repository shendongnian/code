    int[] list = new[] { 1, 2, 3, 4, 5, 6, 7, 0, 1, 2, 3 };
    Func<int, bool> condition = i => i > 0;
    int needed = 1;
    var query = list.Select(item => new
                     {
                         item,
                         needed = condition(item)
                             ? needed
                             : needed--
                     })
                    .While(x => x.needed > 0)
                    .Select(x => x.item);
    if (needed != 0)
        throw new InvalidOperationException("Sequence is not properly terminated");
