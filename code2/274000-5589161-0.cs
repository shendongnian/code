    Row newRow = new Row();  
    newRow.ID = idInfo;  
    // presuming Cells is a List<>
    newRow.Cells.AddRange(Columns.Select(c => new Cell(c.Id)));
    Rows.Add(newRow); 
