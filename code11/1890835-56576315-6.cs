    void ImportJson<T>(string path,string tableName,string[] fields)
    {
        var json=File.ReadAllText(path);
        var data=JsonConvert.DeserializeObject<List<T>>(json);
        using(var bcp = new SqlBulkCopy(connection)) 
        using(var reader = ObjectReader.Create(data, fields)) 
        { 
            bcp.DestinationTableName = tableName; 
            bcp.WriteToServer(reader); 
        }
    }
