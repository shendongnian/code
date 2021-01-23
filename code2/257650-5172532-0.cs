    var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
    var result = new List<List<int>>();
    while (list.Count != 0) {
        result.Add(list.TakeWhile(x => x++ <= 5).ToList());
        list.RemoveRange(0, list.Count < 5 ? list.Count : 5);
    }
