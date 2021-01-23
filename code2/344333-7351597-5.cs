    List<int> numList = new List<int>();
    for (int i = 0; i < 10; i++) numList.Add(2 * i);
    int selectedIndex = 5; // selected at runtime
    List<int> newNumList = numList.Take(selectedIndex)
                                  .Concat(numList.Skip(selectedIndex + 1))
                                  .Concat(numList.Skip(selectedIndex).Take(1))
                                  .ToList();
