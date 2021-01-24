    private static void Watcher_Changed(object sender, FileSystemEventArgs e)
    {
        PictureBox pictureBox;
        switch (e.Name.ToLowerInvariant())
        {
            case "normal.jpg": pictureBox = pictureBoxNormalImg; break;
            case "segmentation.jpg": pictureBox = pictureBoxSegmentation; break;
            default: pictureBox = null; break;
        }
        if (pictureBox != null)
        {
            Image image = null;
            try
            {
                using (var temp = new Bitmap(e.FullPath))
                {
                    image = new Bitmap(temp);
                }
            }
            catch { } // Swallow exception
            if (image != null)
            {
                pictureBox.Invoke((MethodInvoker)(delegate ()
                {
                    pictureBox.Image = image;
                }));
            }
        }
    }
