    private void ctlVSDrop_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetFormats().Contains("CF_VSSTGPROJECTITEMS"))
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
    private void ctlVSDrop_DragDrop(object sender, DragEventArgs e)
    {
        var vsObject = new VisualStudioDataObject(e.Data);
    }
