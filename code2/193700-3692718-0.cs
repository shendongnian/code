    private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      ComboBoxItem item = comboBox1.SelectedItem as ComboBoxItem;
      if (item != null)
      {
        switch (item.Content.ToString())
        {
          // ... Rest of your code here
        }
      }
    }
