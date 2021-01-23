    Bitmap b = new Bitmap(pbAssetLoaded.Width, pbAssetLoaded.Height);
    using (Graphics g = Graphics.FromImage(b))
    {
        g.DrawIcon(SystemIcons.Information, 0, 0);
    }
