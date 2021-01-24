    foreach (dynamic dynamicTable in dynMessage.SourceData)
    {
        context.Logger.Log($"table -> {dynMessage.TableReference.IncludedTables[tableIndex].ToString()} outer -> {dynamicTable}");
    
        string s = JsonConvert.SerializeObject(dynamicTable);
        s = s.Trim().TrimStart('[').TrimEnd(']');
        DataTable dt = (DataTable)JsonConvert.DeserializeObject(s, (typeof(DataTable)));
        context.Logger.LogLine($"DataTableRows={dt.Rows.Count}");
    
        tableIndex++;
    }
