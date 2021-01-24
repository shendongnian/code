    foreach (UIElement item in grid.Children)
    {
        if (item is ComboBox)
        {
            ComboBox comboBox = item as ComboBox;
            if (comboBox.SelectedIndex == -1)
                teachingTip.Visibility = Visibility.Visible;
        }
    }
