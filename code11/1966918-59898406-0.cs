    var item = MainList.Select(x => 
        new { 
            name = string.IsNullOrEmpty(x.name) ? "Not Available" : x.name,
            //Same for other properties
        }
    ).FirstOrDefault();
    LC = item.name;
    //Same for other properties
