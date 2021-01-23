    public void AddItem(string newItem)
    {
     
        if (listView1.InvokeRequired)
        {
            if (stopInvoking != true) // don't start new invokes if the flag is set
            {
                invokeInProgress = true;  // let the form know if an invoke has started
     
                listView1.Invoke(new Action(() => addItem(newItem)));  // invoke
     
                invokeInProgress = false;  // the invoke is complete
            }
     
            return;
        }
     
        listView1.Items.Add(newItem);
        listView1.Items[listView1.Items.Count - 1].EnsureVisible();
    }
