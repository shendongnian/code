    public void UpdateDatabase(IEnumerable<Title> titleList)
    {
        string sql = "update titles Set title= @title, titleType= @titleType, price= @price , pubdate= @pubDate , pubID= @pubID where ID= @ID";
        using (var connection = new SqlConnection(Helper.CnnVal("CsharpMD3")))
        using (var command = new SqlCommand(sql, connection))
        {
            //Use actual column types and lengths from the DB here.
            command.Parameters.Add("@title", SqlDbType.NVarChar, 100);
            command.Parameters.Add("@titleType", SqlDbType.NVarChar, 20);
            command.Parameters.Add("@price", SqlDbType.Decimal, 6, 2);
            command.Parameters.Add("@pubDate", SqlDbType.DateTime2);
            command.Parameters.Add("@pubID", SqlDbType.Int);
            command.Parameters.Add("@ID", SqlDbType.Int);
            connection.Open();
            foreach (var item in titleList)
            {
                command.Parameters["@title"].Value = item.title;
                command.Parameters["@titleType"].Value = item.TitleType;
                command.Parameters["@price"].Value = item.Price;
                command.Parameters["@pubDate"].Value = item.PubDate;
                command.Parameters["@pubID"].Value = item.PubID;
                command.Parameters["@ID"].Value = item.ID;
                command.ExecuteNonQuery();                
            }
        }
    }
