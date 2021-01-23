    string Image = "";
    if (Request.Files != null  && Request.Files.Count > 0)
                {
                     Image = Request.Files.AllKeys[0];
                }
    var stream  = new FileStream(Image,FileMode.Open);
