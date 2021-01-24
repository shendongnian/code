    var list1 = new List<int> {1, 2, 3, 5};
    var list2 = new List<int> {1, 2, 4, 5, 6};
    var differences = list1.Where(v => !list2.Contains(v)).Concat(
                      list2.Where(v => !list1.Contains(v)));
    // Or this compact version:
    // var differences = list1.Except(list2).Concat(list2.Except(list1));
