    var list1 = new List<int> { 1, 2, 3, 4, 5 };
    var list2 = new List<int> { 4, 5, 6, 7, 8 };
    var intersectingValues = list1.Intersect(list2); // 4, 5
    var interesectingValueIndexes = intersectingValues.Select(x => 
                                       new { I1 = list1.IndexOf(x), I2 = list2.IndexOf(x) });
    var otherList1 = new List<string> { "a", "b", "c", "d", "e" };
    var otherList2 = new List<string> { "f", "g", "h", "i", "j" };
    var otherListIndexValues = interesectingValueIndexes.Select(x => 
                                       new { V1 = otherList1[x.I1], V2 = otherList2[x.I2] });
