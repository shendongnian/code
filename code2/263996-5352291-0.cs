    foreach(KeyValuePair<int,Node> i in nodes)
    {    
       ScatterViewItem item = new ScatterViewItem();    
       item.Content = i.Value.Argument;    
       item.Tag = i.Value;    
       item.Name = "NodeID" + i.Key.ToString(); // set the name property
       ActionArea.Items.Add(item);
    }
