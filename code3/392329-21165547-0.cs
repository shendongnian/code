    DataAccess.MyTable MyTable = new DataAcess.MyTable();
    MyTable.LoadAll();
    row[col1] = MyTable.Username;
    row[col2] = MyTable.FirstName + MyTable.LastName;
    row[col3] = MyTable.Age;
    row[col4] = MyTable.Job;
