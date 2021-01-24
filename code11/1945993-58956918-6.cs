    public int InsertTitle(Title toInsert)
    {
        string sql = "insert into dbo.titles (title, titleType, price, pubdate, pubID) VALUES (@title, @titleType, @price, @pubDate, @pubID);select scope_identity();";
        using (var connection = new SqlConnection(Helper.CnnVal("CsharpMD3")))
        using (var command = new SqlCommand(sql, connection))
        {
            command.Parameters.Add("@title", SqlDbType.NVarChar, 100).Value = toInsert.title;
            command.Parameters.Add("@titleType", SqlDbType.NVarChar, 20).Value = toInsert.titleType;
            command.Parameters.Add("@price", SqlDbType.Decimal, 6, 2).Value = toInsert.Price;
            command.Parameters.Add("@pubDate", SqlDbType.DateTime2).Value = toInsert.PubDate;
            command.Parameters.Add("@pubID", SqlDbType.Int).Value = toInsert.PubID;
            connection.Open();
            toInsert.ID = (int)command.ExecuteScalar();
            return toInsert.ID;
        }
    }
