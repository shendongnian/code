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
            var image = Image.FromFile(e.FullPath);
            pictureBox.Invoke((MethodInvoker)(delegate ()
            {
                pictureBox.Image = image;
            }));
        }
    }
