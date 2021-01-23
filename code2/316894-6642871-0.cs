    var QueryCommand = new MySqlCommand(txtQuery.Text, Connection);
    var ResultReader = QueryCommand.ExecuteReader();
    
    for (var f = 0; f < ResultReader.FieldCount; f++)
    {
       ResultGrid.Columns.Add("column" + f, ResultReader.GetName(f));
    }
