    private void ListBox_MouseMove(object sender, MouseEventArgs e)
        {
            DataObject dataObj = new DataObject();
            dynamic Booth = listBox.SelectedItem as dynamic;
            if (sender is ListBox && e.LeftButton == MouseButtonState.Pressed)
            {
                dataObj.SetData("Name", Booth.Name);
                dataObj.SetData("Path", Booth.Path);
                DragDrop.DoDragDrop(listBox, dataObj, DragDropEffects.Move);
            }
        }
