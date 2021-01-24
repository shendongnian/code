    static void Main(string[] args)
    {
        HttpListener listen = new HttpListener();
        string url = "http://localhost";
        string port = "";
        Console.Write("Nastavite port:");
        port = Console.ReadLine();
        url = url + ":" + port + "/geoserver/";
        listen.Prefixes.Add(url);
        listen.Start();
    
        while (true)
        {
            Console.WriteLine("Cakam...");
            HttpListenerContext kontekst = listen.GetContext();
            
            kontekst.Response.StatusCode = (int)HttpStatusCode.OK;
            
            using (Stream stream = kontekst.Response.OutputStream)
            using (Image image = Image.FromFile("test-img.jpg"))
            using (MemoryStream ms = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(stream))
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                string base64 = Convert.ToBase64String(ms.ToArray());
                writer.WriteLine($"<html><img src=\"data: image / png; base64, {base64} \"></html>");
            }
    
            Console.WriteLine("Sporočilo poslano");
        }
    }
