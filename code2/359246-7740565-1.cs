     IList<int> values = new List<int> { 1, 2, 3, 4, 5 };
     IList<int> emptyValues = new List<int> { };
     int max = values.DefaultIfEmpty(Int32.MinValue)
                                        .Max();
     // do not throw exception
     int maxEmpty = emptyValues.DefaultIfEmpty(Int32.MinValue)
                               .Max();
    // max == 5
    // maxEmpty == Int32.MinValue
