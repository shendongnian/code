    static IEnumerable<IEnumerable<int>>
        ConsecutiveSequences(this IEnumerable<int> input, int minLength = 3)
    {
        int order = 0;
        var inorder = new SortedSet<int>(input);
        return from item in new[] { new { order = 0, val = inorder.First() } }
                   .Concat(
                     inorder.Zip(inorder.Skip(1), (x, val) =>
                             new { order = x + 1 == val ? order : ++order, val }))
               group item.val by item.order into list
               where list.Count() >= minLength
               select list;
    }
