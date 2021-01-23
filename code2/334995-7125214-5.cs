    MyClassDataRow Object1 = MyDataSet.MyClassTable.NewRow();
    Object1.Prop1 = 123;
    Object2.Prop2 = "Hello Dataset";
    // etc...
    MyClass2DataRow Object2 = MyDataSet.MyClass2Table.NewRow();
    foreach (DataColumn ColumnName in MyClassTable.Columns) 
        Object2[ColumnName] = Object1[ColumnName];
