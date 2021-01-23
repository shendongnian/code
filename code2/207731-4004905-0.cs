    private void DragSource_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    {	
        //...
    	DataObject data = new DataObject("Object", new string[]{"1", "2", "3"});
        DragDropEffects effects = DragDrop.DoDragDrop(this.draggingElement, data, DragDropEffects.Move);
    	//...
    }
    
    private void PictureBox_Drop(object sender, DragEventArgs e)
    {
        string[] files = (string[])e.Data.GetData("Object");
    	//...
    }
