    public string CheckedRadioButtonContent
    {
        get;
        set;
    }
    private void OKButton_Click(object sender, RoutedEventArgs e)
    {
        if (a_RD.IsChecked == true)
        {
            CheckedRadioButtonContent = a_RD.Content.ToString();
        }
        else if (b_RD.IsChecked == true)
        {
            CheckedRadioButtonContent = b_RD.Content.ToString();
        }
        else if (c_RD.IsChecked == true)
        {
            CheckedRadioButtonContent = c_RD.Content.ToString();
        }
        DialogResult = true;
    }
