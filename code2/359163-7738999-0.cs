    var source = new int[3][] {
        Enumerable.Range(1,3).ToArray(),
        Enumerable.Range(10,5).ToArray(),
        Enumerable.Range(100,10).ToArray()
    };
    int index = 0;
    
    var result = (from array in source
                    from item in array
                    group item by Array.IndexOf(array, item) into g
                    where g.Key == index
                    select g.ToArray()).FirstOrDefault();
