    private ListBox _DraggingListBox = null;
    private void listBox1_DragDrop(object sender, DragEventArgs e)
    {
      if (_DraggingListBox != listBox1)
        MoveItem(listBox2, listBox1, (int)e.Data.GetData(typeof(int)));
    }
    private void listBox1_MouseDown(object sender, MouseEventArgs e)
    {
      _DraggingListBox = listBox1;
      listBox1.DoDragDrop(listBox1.IndexFromPoint(e.X,e.Y), DragDropEffects.Move);    
    }
    private void listBox1_DragOver(object sender, DragEventArgs e)
    {
      e.Effect = DragDropEffects.Move;
    }
    private void listBox2_DragDrop(object sender, DragEventArgs e)
    {
      if (_DraggingListBox != listBox2)
        MoveItem(listBox1, listBox2, (int)e.Data.GetData(typeof(int)));
    }
    private void listBox2_DragOver(object sender, DragEventArgs e)
    {
      e.Effect = DragDropEffects.Move;
    }
    private void listBox2_MouseDown(object sender, MouseEventArgs e)
    {
      _DraggingListBox = listBox2;
      listBox2.DoDragDrop(listBox2.IndexFromPoint(e.X,e.Y), DragDropEffects.Move);
    }
    private void MoveItem(ListBox fromLB, ListBox toLB, int index)
    {
      toLB.Items.Add(fromLB.Items[index]);
      fromLB.Items.RemoveAt(index);
    }
