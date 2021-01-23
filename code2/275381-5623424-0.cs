    string tempFile = Path.GetTempFileName();
    MemoryStream ms = new MemoryStream(bytes); //bytes that was read from the db
    //Here I assume that you're reading a png image, you can put any extension you like is a file name
    FileStream stream = new FileStream(tempFile + ".png", FileMode.Create);
    ms.WriteTo(stream);
    ms.Close();
    stream.Close();
    //And here we open the file with the default program
    Process.Start(tempFile + ".png");
