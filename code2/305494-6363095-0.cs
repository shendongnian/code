    private void MyDragDrop(object sender, DragEventArgs e) {
        if (this.IsEnabled)
            MessageBox.Show("dropped");
    }
    private void MyDragEnter(object sender, DragEventArgs e) {
        if (this.IsEnabled)
            e.Effect = DragDropEffects.Copy;
        else
            e.Effect = DragDropEffects.None;
    } 
