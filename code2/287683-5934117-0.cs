    PropertyInfo indexer = hh.GetProperty("Item");  // gets the indexer
    //note the second parameter, that's the index
    object student1 = indexer.GetValue(gg, new object[]{0}); 
    object student2 = indexer.GetValue(gg, new object[]{1}); 
    PropertyInfo name = gggg.GetProperty("Name");
    object studentsName1 = name.GetValue(student1, null); // returns "A"
    object studentsName2 = name.GetValue(student2, null); // returns "B"
