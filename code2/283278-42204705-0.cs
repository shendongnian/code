    string path = "~/image/"; 
    string picture = "Your picture name with extention";
    path = Path.Combine(Server.MapPath(path), picture);
    using (WebClient wc = new WebClient())
                                {
    wc.DownloadFile("http://testsite.com/web/abc.jpg", path);
                                }
