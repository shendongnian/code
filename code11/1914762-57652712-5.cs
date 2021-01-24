    private void TextBox_DataContextChanged(
         FrameworkElement sender, 
         DataContextChangedEventArgs args)
    {
        var textBox = (TextBox)sender;
        if ( args.NewValue == Items.Last())
        {
            //last item, focus it
            textBox.Focus(FocusState.Programmatic);
        }
    }
