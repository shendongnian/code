    Dictionary<int, List<MyValue>> rowsToBeDeleted = new Dictionary<int, List<MyValue>> ();
    class MyValue
    {
      int EmpID;
      int PayID;
      DateTime Date;
    }
    
    rowsToBeDeleted.Add(123, new List<MyValue>);
    rowsToBeDeleted[123].Add(123, 1, new DateTime(2011,8,31);
    rowsToBeDeleted[123].Add(123, 2, new DateTime(2011,10,31);
    
    rowsToBeDeleted.Add(1234, new List<MyValue>);
    rowsToBeDeleted[1234].Add(1234, 1, new DateTime(2011,18,31); // month #18 - wow!
    rowsToBeDeleted[1234].Add(1234, 2, new DateTime(2011,19,31);
