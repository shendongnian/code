    // Create a new dictionary
    Dictionary<int,string> myWeirdList = new Dictionary<int, string>();
    // Add items to it
    myWeirdList.Add(2, "Test, test, Test, test");
    // Retrieve text using key
    var text_using_key = myWeirdList[2];
    // Retrieve text using index
    var text_using_index = myWeirdList.ElementAt(0).Value;
