    exampleList.GroupBy(item => item.Name)
        .Where(g => g.Count() > 1).ToList().ForEach
    (
        group =>
        {
            foreach (var item in group
                .Select((x, i) => new { val = x, idx = i + 1 }))
            {
                item.val.Name += string.Format
                (
                    " ({0} of {1})", item.idx, group.Count()
                );
            }
        }
    );
