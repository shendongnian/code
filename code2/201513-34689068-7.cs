    var fields = new List<Field>() { 
        new Field("EmployeeID", typeof(int)),
        new Field("EmployeeName", typeof(string)),
        new Field("Designation", typeof(string)) 
    };
    dynamic obj = new DynamicClass(fields);
    //set
    obj.EmployeeID = 123456;
    obj.EmployeeName = "John";
    obj.Designation = "Tech Lead";
    
    obj.Age = 25;             //Exception: DynamicClass does not contain a definition for 'Age'
    obj.EmployeeName = 666;   //Exception: Value 666 is not of type String
    //get
    Console.WriteLine(obj.EmployeeID);     //123456
    Console.WriteLine(obj.EmployeeName);   //John
    Console.WriteLine(obj.Designation);    //Tech Lead
