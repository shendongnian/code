    public void PutTheItemInTheSameSpot()
    {
       var listboxitems = (List<Integer>)YourListBox.DataSource;
       
       var originalClikedItem = OriginalItem;
       var topPart = new List<Integer>();
       
       for (i = 0; i < itemPosition; i++)
       {
           topPart.Add(listboxItems[i]);
       }
       topPart.Add(originalClickedItem);
    
       var bottomPart = listboxitems.Remove(toppart);
       
       YourListBox.DataSource = toppart.AddRange(bottomPart);
       
    
    }
