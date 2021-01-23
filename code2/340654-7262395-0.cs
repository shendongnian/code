     if (!data.Tables[0].Columns.Contains("SomeId"))
     {
        var column = new DataColumn("SomeId", typeof(int));
        // give it a default value if you don't want null
        column.DefaultValue = 1;
        // should it support null values?
        column.AllowDBNull = false;
        data.Tables[0].Columns.Add(column);
     }
