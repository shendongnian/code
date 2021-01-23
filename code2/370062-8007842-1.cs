    private void Next_Click(object sender, RoutedEventArgs e)
    {
    	var button = (Button)sender;
    	var cvs = (CollectionViewSource)button.Tag;
    	cvs.View.MoveCurrentToNext();
    }
    
    private void Previous_Click(object sender, RoutedEventArgs e)
    {
    	var button = (Button)sender;
    	var cvs = (CollectionViewSource)button.Tag;
    	cvs.View.MoveCurrentToPrevious();
    }
