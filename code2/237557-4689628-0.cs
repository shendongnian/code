    private void mySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (chkContainer != null) // It could be null during page creation (add event handler after construction to avoid this)
        {
            // The following works because the both the small and large change are one
            // If they were larger you may have to add (or remove) more at a time
            if (chkContainer.Children.Count() < mySlider.Value)
            {
                chkContainer.Children.Add(new CheckBox { Content = mySlider.Value.ToString() });
            }
            else
            {
                chkContainer.Children.RemoveAt(int.Parse(mySlider.Value.ToString()));
            }
        }
    }
