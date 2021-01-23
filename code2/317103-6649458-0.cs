    private delegate void AddListBoxItemDelegate(object item);
    
    private void AddListBoxItem(object item)
    {
       if (this.listBox1.InvokeRequired)
       {
           // This is a worker thread so delegate the task.
           this.listBox1.Invoke(new AddListBoxItemDelegate(this.AddListBoxItem), item);
       }
       else
       {
           // This is the UI thread so perform the task.
           this.listBox1.Items.Add(item);
       }
    }
