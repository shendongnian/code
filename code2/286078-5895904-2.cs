    private void Button_Click(object sender, RoutedEventArgs e)
    {
        int numberOfWords;
        if(Int32.TryParse(textBox1.Text, NumberStyles.Integer, CultureInfo.CurrentUICulture, out numberOfWords))
        {
            ShowMostPopularWords(numberOfWords);
        }
    }
