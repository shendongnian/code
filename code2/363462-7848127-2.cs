    private void ButtonUp_Click(object sender, RoutedEventArgs e)
    {
        // This is an int property
        Quantity++;
        // Now reflect the change in the UI. Ideally, do this through binding
        // instead.
        Qnt.Text = Quantity.ToString();
    }
