    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (Program.SelectedItem != null)
        {
            Step.DataContext = Program.SelectedItem;
        }
    }
