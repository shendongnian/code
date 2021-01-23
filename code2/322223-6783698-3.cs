    /// <summary>This is a bad choice.</summary>
    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
        // assumes the Grid is named MyGrid
        foreach (var textBox in this.MyGrid.Children.OfType<TextBox>())
        {
            textBox.Text = null;
        }
    }
