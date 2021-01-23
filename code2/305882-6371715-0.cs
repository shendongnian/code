    try
    {
        string fileName = imageQueue.Dequeue();
        using( FileStream fileStream = File.Open( fileName, FileMode.Open, FileAccess.Read, FileShare.Read) )
        {
            Bitmap bitmap = new Bitmap(fileStream);
            Image picture = (Image)bitmap;
            pb.Tag = fileName;
            pb.Image = picture;
        }
        return true;
    }
    catch (Exception ex)
    {
        errorCount++;
        //If another PC has this image open it will error
        return false;
    }
