    var hashSet = new HashSet<ComparableReadOnlyCollection<int>>();
    hashSet.Add(new ComparableReadOnlyCollection<int>(new int[] { 1, 7 }));
    Console.WriteLine(hashSet.Contains(new ComparableReadOnlyCollection<int>(new int[] { 1, 7 })));
    hashSet.Add(new ComparableReadOnlyCollection<int>(new int[] { 1, 7 }));
    hashSet.Add(new ComparableReadOnlyCollection<int>(new int[] { 1, 7, 0 }));
    hashSet.Add(new ComparableReadOnlyCollection<int>(new int[] { 7, 1 }));
    Console.WriteLine(hashSet.Count);
