    private void RichTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && Keyboard.IsKeyDown(Key.LeftCtrl))
        {
            // do whatever you want
            // if u want to add a new line just uncomment the next lines
            // rtb.AppendText(Environment.NewLine);
            // rtb.CaretPosition = rtb.CaretPosition.DocumentEnd;
            e.Handled = true;
        }
    }
