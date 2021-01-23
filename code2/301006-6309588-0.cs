    [WebMethod]
    public XmlDocument testuploadimage(string image)
    {
        XmlDocument login = new XmlDocument();
        XmlDeclaration dec = login.CreateXmlDeclaration("1.0", null, null);
        login.AppendChild(dec);
        XmlElement root = login.CreateElement("CreateUser");
        login.AppendChild(root);
        try
        {
    
            string actFolder = Server.MapPath("~/iphoneimg/");
            string imgname = DateTime.UtcNow.ToString().Replace(" ", "").Replace("AM", "").Replace("PM", "").Replace("/", "").Replace("-", "").Replace(":", "") + ".Png";
            
            byte[] imageBytes = Convert.FromBase64String(image.Replace(" ","+"));
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
    
            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image2 = System.Drawing.Image.FromStream(ms, true);
            image2.Save(actFolder + imgname);
    
    
            XmlElement root1 = login.CreateElement("uploaded");
            root1.InnerText = "true";
            root.AppendChild(root1);
            XmlElement root2 = login.CreateElement("path");
            root2.InnerText = "http://d8768157.u118.c6.ixwebhosting.com/iphoneimg/" + imgname;
            root.AppendChild(root2);
    
            return login;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    
    }
