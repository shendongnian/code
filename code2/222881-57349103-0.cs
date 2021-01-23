     private void form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void form_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths= (string[])e.Data.GetData(DataFormats.FileDrop, false);
        }
