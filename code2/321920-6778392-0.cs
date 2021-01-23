    private static void OnHelpsListViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        // ListView listview = d as ListView;
        // the propblem was with the line above, I was trying to convert the 
        // DependencyObject to a ListView and it's actually a TextBox, I should 
        // have been converting the new value of the DependencyProperty
        TextBox box = d as TextBox;
        ListView list = e.NewValue as ListView;
        if(box == null || list == null) return;
        box.PreviewKeyDown += delegate(object sender, KeyEventArgs e2)
        {
            if (e2.Key == Key.Down)
                list.SelectedIndex += (list.SelectedIndex + 1 < list.Items.Count) ? 1 : 0;
            else if (e2.Key == Key.Up)
                list.SelectedIndex -= (list.SelectedIndex - 1 >= 0) ? 1 : 0;
            else if (e2.Key == Key.Enter && list.SelectedIndex >= 0)
            { 
                // do something for the enter key 
            }
        };
    }
