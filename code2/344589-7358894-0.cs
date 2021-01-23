    Dictionary<int, MyValue> dict = new Dictionary<int, MyValue>();
    
    MyValue val = new MyValue();
    // assuming you need to bind 3 employees to this value
    MyValue.EmployeeList.AddRange(1, 2, 3); 
    // then you have to add the MyValue to the Dictionary 3 times:
    dict.Add(1, MyValue);
    dict.Add(2, MyValue);
    dict.Add(3, MyValue);
