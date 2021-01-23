    public void SetButtons(object toolstrip, int IconWidth, int IconHeight)
    {
        var ts = (ToolStrip) toolstrip;
        var size = new System.Drawing.Size();
        size.Height = IconSize;
        size.Width = IconSize;
        foreach (ToolStripButton tsBtn in ts.Items)
        {
            tsBtn.ImageScaling = ToolStripItemImageScaling.None;
            var resourcename = (String) tsBtn.Tag;
            if (resourcename != null)
            {
                var myIcon = (Icon) Properties.Resources.ResourceManager.GetObject(resourcename);
                var newIcon = new Icon(myIcon, IconWidth, IconHeight);
                tsBtn.Image = newIcon.ToBitmap();
            }
        }
    }
