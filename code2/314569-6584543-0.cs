    var source = from p in CommentsList
                 select new { p.Img, p.Name, p.Comment };
    dt.Columns.Add("User");
    dt.Columns.Add("Comment");
    dt.Columns.Add("Img");
