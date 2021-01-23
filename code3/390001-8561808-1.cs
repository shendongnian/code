    for(int i=0;i<ListBoxSource.Items.Count;i++)
    {
       Image currentImageItem = ListBoxSource.Items[i] as Image;
            Image image = new Image();
            image.Source = currentImageItem.Source ; 
       ListBoxDisplay.Items.Add(image);
    }
