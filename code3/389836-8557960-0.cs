    HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(imgURL);
    using(WebResponse response = Request.GetResponse())
    using(Stream str = response.GetResponseStream())
    using(System.Drawing.Image objTempImg = System.Drawing.Image.FromStream(str))
    {
        objTempImg.Save(FileName, ImageFormat.Jpeg);
    }
    return File.ReadAllBytes(FileName);
