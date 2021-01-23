    int itemsInGroup = 2;
    var pairs = nums.
                Select((n, i) => new { GroupNumber = i / itemsInGroup, Number = n }).
                GroupBy(n => n.GroupNumber).
                Select(g => g.Select(n => n.Number).ToList()).
                ToList();
