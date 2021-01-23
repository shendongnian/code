    var Items = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    
    Items.Select( ( i, index ) => new {
                                          category = index % 4,
                                          value = i
                                      } )
            .GroupBy( itm => itm.category, itm => itm.value )
            .ToList()
            .ForEach( gr => Console.WriteLine("Group {0} : {1}", gr.Key, string.Join(",", gr)));
    /* output
    Group 0 : 1,5,9
    Group 1 : 2,6,10
    Group 2 : 3,7
    Group 3 : 4,8
    */
