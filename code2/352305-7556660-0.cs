    private void Form1_DragOver(object sender, DragEventArgs e)
    {
      e.Effect = DragDropEffects.Copy;
    }
    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
      // Examine e.Data.GetData stuff
    }
