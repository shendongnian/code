    string name1, name2, name3;
    name1 = "test";
    name2 = null;
    name3 = null;
    List<string> fieldList = new List<string>() { name1, name2, name3 }; //name of the fields
    var nullOrEmptyElementes = fieldList.Where(e => string.IsNullOrEmpty(e)).ToList();
