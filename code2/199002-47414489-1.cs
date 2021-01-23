    IEnumerable<MyClass> myObjects = ...
    // check if has duplicates:
    bool hasDuplicates = myObjects.ExtractDuplicates().Any();
    // or find the first three duplicates:
    IEnumerable<MyClass> first3Duplicates = myObjects.ExtractDuplicates().Take(3)
    // or find the first 5 duplicates that have a Name = "MyName"
    IEnumerable<MyClass> myNameDuplicates = myObjects.ExtractDuplicates()
        .Where(duplicate => duplicate.Name == "MyName")
        .Take(5);
