    `public ActionResult GetImage(int id)
    {
        var article = db.Articles.First(i => i.Id == id);
        return File(article.image, "image/png"); //Adjust content type based on image type (jpeg, gif, png, etc.)
    }`
