    private bool IsBoldStylePending { get; set; }
    private void RichTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if (!IsBoldStylePending)
            return;
        rtb.BeginChange();
        Run run = new Run(e.Text, rtb.CaretPosition);  // Add the next character with style
        run.FontWeight = FontWeights.Bold;
        rtb.EndChange();
        rtb.CaretPosition = run.ElementEnd;            // Keep caret just within the run
        IsBoldStylePending = false;
        e.Handled = true;
    }
