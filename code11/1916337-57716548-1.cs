    private void button_Click(object sender, RoutedEventArgs e)
    {
        TextRange MyText = new TextRange(
        richTextBox1.Document.ContentStart,
        richTextBox1.Document.ContentEnd
         );
    
        string[] splittedLines = MyText.Text.Split(new[] { Environment.NewLine }
                                      , StringSplitOptions.None); // or StringSplitOptions.RemoveEmptyEntries
    
        MessageBox.Show(splittedLines.Length.ToString());
    }
