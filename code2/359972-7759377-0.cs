    using (var conn = new SqlConnection("some conn string"))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "insert into tbl_articles (Text) values (@Text)";
        cmd.Parameters.AddWithValue("@Text", article.ArticleText);
        cmd.ExecuteNonQuery();
    }
