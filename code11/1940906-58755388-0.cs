    byte[][] imgdata = image.ImageByteArrayList;
    using (FileStream file = new FileStream(FileNameLocation, FileMode.Create, System.IO.FileAccess.Write))
    {
        for (int i = 0;  i < imgdata.Length;  i++)
            file.Write(imgdata[i], 0, imgdata[i].Length);   // Write a row of bytes
        file.Flush();
        file.Close();
        file.Dispose();
    }
