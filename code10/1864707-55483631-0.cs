    var columnOptions = new ColumnOptions
    {
        AdditionalDataColumns = new Collection<DataColumn>
        {
            new DataColumn {DataType = typeof (string), ColumnName = "User"},
            new DataColumn {DataType = typeof (string), ColumnName = "Other"},
        }
    };
