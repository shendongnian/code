    private List<MyObject> lstMyObject = new List<MyObject>();
    
    private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (MyObject item in e.RemovedItems)
        {
            lstMyObject.Remove(item);
        }
    
        foreach (MyObject  item in e.AddedItems)
        {
           lstMyObject.Add(item);
        }
    }
