    using (OdbcCommand cmd = new OdbcCommand("SELECT Wallpostings FROM WallPosting WHERE UserID=" + theUserId + "", cn))
    using (OdbcDataReader reader = cmd.ExecuteReader())
    {       
        var divHtml = new System.Text.StringBuilder(); 
        while (reader.Read())
        {
            var divHtml.AppendFormat("<div class=\"mysqlcontent\">{0}</div>", reader.GetString(0));
        }
        test1.InnerHtml = divHtml.ToString();
    }
