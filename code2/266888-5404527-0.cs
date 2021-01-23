       using (OdbcCommand cmd = new OdbcCommand("SELECT Wallpostings FROM WallPosting WHERE UserID=" + theUserId + "", cn))
    
        using (OdbcDataReader reader = cmd.ExecuteReader())
        {
            var divHtml = new System.Text.StringBuilder();
            while (reader.Read())
            {
                divHtml.Append("<div id=mysqlcontent>");
                divHtml.Append(String.Format("{0}", reader.GetString(0)));
                divHtml.Append("</div>");
            }
    
    
            test1.InnerHtml = divHtml.ToString();
    
        }
    }
