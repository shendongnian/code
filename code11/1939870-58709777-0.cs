    var ext = Path.GetExtension(filename);
    var imageExtensions=new[]{".jpg",".jpeg",".png",".gif",".bmp"};
    var isimage = imageExtensions.Contains(ext);
    var request = (FtpWebRequest)WebRequest.Create("ftp://someurl.com/Folder1/test1.jpg");
    
        request.UseBinary =isimage;
        request.Method = WebRequestMethods.Ftp.UploadFile;
        request.ConnectionGroupName = "Group1";
        request.ServicePoint.ConnectionLimit = 4;
        //These are the credentials.
        request.Credentials = new NetworkCredential("username", "password");
        using(var sourceStream = File.OpenRead(filename))
        using(var requestStream = await request.GetRequestStreamAsync())
        {
            await sourceStream.CopyToAsync(requestStream);
        }
        using(var responseWeb = await request.GetResponseAsync())
        {
            var response = (FtpWebResponse)responseWeb;
            if (response.StatusDescription.Contains("226"))
            {
                 return true;
            }
        }
    .....
    
