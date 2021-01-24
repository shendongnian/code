    if (product.imagebase64 != null)
    {
        try
        {
             var base64Data = Regex.Match(product.imagebase64, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
             byte[] imageBytes = Convert.FromBase64String(base64Data);
             string filename = DateTime.Now.ToString("ddMMyyyy_hhmmss"); // You can write custom name here
             string path = Path.Combine(Server.MapPath("~/ProductImages"), filename + ".jpg");
             System.IO.File.WriteAllBytes(path, imageBytes);
        }
        catch (Exception ex)
        {
        }
    }
