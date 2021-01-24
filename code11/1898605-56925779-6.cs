    try
    {
        Console.WriteLine("start " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
    
        using (ClientContext context = new ClientContext("[URL]"))
        {
            context.Credentials = new NetworkCredential("[LOGIN]","[PASSWORD]","[DOMAIN]");
            context.RequestTimeout = -1;
            Web web = context.Web;
            if (context.HasPendingRequest)
                context.ExecuteQuery();
    
            byte[] fileBytes;
            using (var fs = new FileStream(@"D:\OneGB.rar", FileMode.Open, FileAccess.Read))
            {
                fileBytes = new byte[fs.Length];
                int bytesRead = fs.Read(fileBytes, 0, fileBytes.Length);
            }
    
            using (var fileStream = new System.IO.MemoryStream(fileBytes))
            {
                Microsoft.SharePoint.Client.File.SaveBinaryDirect(context, "/Shared Documents/" + "OneGB.rar", fileStream, true);
            }
        }
    
        Console.WriteLine("end " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
    }
    catch (Exception ex)
    {
        Console.WriteLine("error -> " + ex.Message);
    }
    finally
    {
        Console.ReadLine();
    }
