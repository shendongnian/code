    private void TvItemDisplay_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
            {
                LvItemDisplay.SelectionChanged -= LvItemDisplay_SelectionChanged;
                ParentItemSelectionChange(sender, true);         
               
                // Your code
    
                ParentItemSelectionChange(sender, false);
                LvItemDisplay.SelectionChanged += LvItemDisplay_SelectionChanged;
    
            }
