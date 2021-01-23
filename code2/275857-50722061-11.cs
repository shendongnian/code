    var list1 = new List<int> { 1, 2, 3, 4, 5};
    var list2 = new List<int> { 3, 4, 5, 6, 7 };
    
    var list3 = list1.Except(list2); //list3 contains only 1, 2
    var list4 = list2.Except(list1); //list4 contains only 6, 7
    var resultList = list3.Concat(list4).ToList(); //resultList contains 1, 2, 6, 7
