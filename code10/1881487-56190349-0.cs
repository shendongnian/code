    var newDataRow = medicareBuyInBuyInDataTable.NewRow();
    foreach (var value in values) {
    
        newDataRow["FieldName"] = value;
        ....
        ....
    }
    yourDataTable.Rows.Add(newDataRow);
    // sent your table as parameter
     var parameter = new List<KeyValuePair<string, object>>{
                    new KeyValuePair<string, object>("@yourTableParam", medicareBuyInDataTable)
                };
     return DbAccess.ExecuteScalar(ConString, StoreProcedureName, parameter);
