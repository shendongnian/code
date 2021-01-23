    private void MyDragDrop(object sender, DragEventArgs e) {
        if (CanFocus)
            MessageBox.Show("dropped");
    }
    private void MyDragEnter(object sender, DragEventArgs e) {
        if (CanFocus)
            e.Effect = DragDropEffects.Copy;
        else
            e.Effect = DragDropEffects.None;
    } 
