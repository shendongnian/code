    // Extract the blog id before the query, because this instruction can't be translated to SQL
    int blogId = int.Parse(codesnippets.Decrypt(Request["blg"].ToString(), true));
    var ratings = from x in db.DT_Control_BlogRatings
                  where x.Blog_ID == blogId
                  select x.RatingNo;
    var avg = ratings.Average();
