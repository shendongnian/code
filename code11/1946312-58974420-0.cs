    string base64EncodedFile = // Get the string representation from the api
    using (System.IO.FileStream stream = System.IO.File.Create("c:\\saved.pdf))
    {
        System.Byte[] byteArray = System.Convert.FromBase64String(base64EncodedFile);
        stream.Write(byteArray, 0, byteArray.Length);
    }
