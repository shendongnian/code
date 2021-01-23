    #region Drop target accepting FileDrop
    private void textBox2_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            e.Effect = e.AllowedEffect & DragDropEffects.Copy;
            DropTargetHelper.DragEnter(textBox2, e.Data, new Point(e.X, e.Y), e.Effect, "Copy to %1", "Here");
        }
        else
        {
            e.Effect = DragDropEffects.None;
            DropTargetHelper.DragEnter(textBox2, e.Data, new Point(e.X, e.Y), e.Effect);
        }
    }
    private void textBox2_DragOver(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = e.AllowedEffect & DragDropEffects.Copy;
        else
            e.Effect = DragDropEffects.None;
        DropTargetHelper.DragOver(new Point(e.X, e.Y), e.Effect);
    }
    private void textBox2_DragLeave(object sender, EventArgs e)
    {
        DropTargetHelper.DragLeave(textBox2);
    }
    private void textBox2_DragDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = e.AllowedEffect & DragDropEffects.Copy;
        else
            e.Effect = DragDropEffects.None;
        DropTargetHelper.Drop(e.Data, new Point(e.X, e.Y), e.Effect);
        if (e.Effect == DragDropEffects.Copy)
            AcceptFileDrop(textBox2, e.Data);
    }
    #endregion // Drop target accepting FileDrop
