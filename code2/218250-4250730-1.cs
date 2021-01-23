    BoundField Col1 = new BoundField();
    Col1.DataField = "StringFieldName";
    
    BoundField Col2 = new BoundField();
    Col2.DataField = "DateFieldName";
    Col2.DataFormatString = "{0:d}";
    
    grdTest.Columns.Add(Col1);
    grdTest.Columns.Add(Col2);
