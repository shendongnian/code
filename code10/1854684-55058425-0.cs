    // flatten your list:
    var newList = new List<int>();
    foreach (var list in output) {
      newList.AddRange(list);
    }
    // make sure every number is only once in that list:
    newList.Distinct() // here is linq!
    var output = new List<List<int>>();
    output.Add(newList);
