    private static List<Details> LoadData()
    {
        List<Details> infoObjs = new List<Details>();
    
        using (SqlConnection con = new SqlConnection(cs))
        {
            // ...
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Details infoObj = new Details();
                infoObj.CommentsID = rdr["COMMENT_ID"].ToString();
                infoObj.Comments = rdr["COMMENT"].ToString();
                infoObj.Status = rdr["STATUS"].ToString();
                infoObj.Date = rdr["DATE"].ToString();
                infoObj.Action = "<a class='btn btn-warning' data-id=" + infoObj.CommentsID + " ID=" + infoObj.CommentsID + 
                    "> <i class=\"fas fa-pencil-alt\" aria-hidden=\"true\"></i></a>";
                //This button needs to open a modal.
                infoObjs.Add(infoObj);
            }
        }
    
        return infoObjs;
    }
