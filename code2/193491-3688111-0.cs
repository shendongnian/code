    for (int i = 0; i < ds.Tables[0].Columns.Count; i++ )
    {
        DataColumn col = ds.Tables[0].Columns[i] != null ? ds.Tables[0].Columns[i] : "<some default value>";
        if (col != "<some default value>")
                        // do something
    }
