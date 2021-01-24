        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBoxItem = (e.AddedItems[0] as ListBoxItem);
            button.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(listBoxItem.Content.ToString());
        }
            
