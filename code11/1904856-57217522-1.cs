    var listA = new List<DataDictionary>()
    {
        new DataDictionary() {TableName = "Table A"},
        new DataDictionary() {TableName = "Table B"},
    };
    
    var listB = new List<DataDictionary>()
    {
        new DataDictionary() {TableName = "Table A"},
        new DataDictionary() {TableName = "Table C"},
    };
    
    var tableNameComparer = new TableNameEqualityComparer();
