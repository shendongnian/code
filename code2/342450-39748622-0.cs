    public void PostImageOnPage()
    {
    string filename=string.Empty;
    if(ModelState.IsValid)
    {
    //-------- save image in image/
    if (System.Web.HttpContext.Current.Request.Files.Count > 0)
    {
    var file = System.Web.HttpContext.Current.Request.Files[0];
    // fetching image                    
    filename = Path.GetFileName(file.FileName);
    filename = DateTime.Now.ToString("yyyyMMdd") + "_" + filename;
    file.SaveAs(Server.MapPath("~/images/Advertisement/") + filename);
    }
    }
    string Picture_Path = Server.MapPath("~/Images/" + "image3.jpg");
    string message = "my message";
    try
    {
    string PageAccessToken = "EAACEdEose0cBAAoWM3X";
    
    // ————————create the FacebookClient object
    FacebookClient facebookClient = new FacebookClient(PageAccessToken);
    
    // ————————set the parameters
    dynamic parameters = new ExpandoObject();
    parameters.message = message;
    parameters.Subject = "";
    parameters.source = new FacebookMediaObject
    {
    ContentType = "image/jpeg",
    FileName = Path.GetFileName(Picture_Path)
    }.SetValue(System.IO.File.ReadAllBytes(Picture_Path));
    // facebookClient.Post("/" + PageID + "/photos", parameters);// working for notification on user page
    facebookClient.Post("me/photos", parameters);// woring using bingoapp access token not page in(image album) Post the image/picture to User wall   
    }
    catch (Exception ex)
    {
    
    }
    }
