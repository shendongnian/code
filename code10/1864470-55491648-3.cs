    public ActionResult Article(int id)
    {
        List<NewsData> oneList = new List<NewsData>();
        var data = new NewsData();
        //Return the first element that matches the specified criteria or null if nothing is found
        data=db.NewsData.Where(xx => xx.ArticleID == data.ArticleID).FirstOrDefault();
        data.ArticleID = id;
        return View(from NewsData in db.NewsData.ToList() select NewsData);
    }
