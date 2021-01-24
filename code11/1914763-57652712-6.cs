    //set this to true when a new item is being added to the collection
    private bool _focusItem = true;
    private void TextBox_DataContextChanged(
         FrameworkElement sender, 
         DataContextChangedEventArgs args)
    {
        var textBox = (TextBox)sender;
        if (args.NewValue == Items[Items.Count - 1] && _focusItem)
        {
            //last item, focus it
            textBox.Focus(FocusState.Programmatic);
            _focusItem = false;
        }
    }
