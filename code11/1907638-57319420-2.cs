    public bool ScrollViewerAScrolled = false;
    public bool ScrollViewerBScrolled = false;
    ListViewA.PointerEntered += ListViewA_PointerEntered;
    ListViewB.PointerEntered += ListViewB_PointerEntered;
    private void ListViewB_PointerEntered(object sender, PointerRoutedEventArgs e)
            {​
                ScrollViewerBScrolled = true;​
                ScrollViewerAScrolled = false;​
            }​
   
    private void ListViewA_PointerEntered(object sender, PointerRoutedEventArgs e)​
            {​
                ScrollViewerAScrolled = true;​
                ScrollViewerBScrolled = false;​
            }
  
