    private void button_Click(object sender, RoutedEventArgs e)
    {
        TextRange MyText = new TextRange(
        richTextBox1.Document.ContentStart,
        richTextBox1.Document.ContentEnd
         );
    
        string[] splittedLines = MyText.Text.Split(new[] { Environment.NewLine }
                                      , StringSplitOptions.RemoveEmptyEntries); // or StringSplitOptions.None
    
        MessageBox.Show(splittedLines.Length.ToString());
    }
