    private bool _shiftTabKeyDown;
    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        _shiftTabKeyDown = false;
        if (e.KeyCode == Keys.Tab && e.Shift) {
            _shiftTabKeyDown = true;
        }
    }
    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (textBox1.SelectionLength == 0 || e.KeyChar != '\t') {
            return;
        }
        bool startNewLineAdded = false;
        bool endNewLineRemoved = false;
        string selection = textBox1.SelectedText;
        if (!selection.StartsWith(Environment.NewLine)) {
            selection = Environment.NewLine + selection;
            startNewLineAdded = true;
        }
        if (selection.EndsWith(Environment.NewLine)) {
            selection = selection.SubString(0, selection.Length
                - Environment.NewLine.Length);
            endNewLineRemoved = true;
        }
        if (_shiftTabKeyDown) {
            selection = selection.Replace(Environment.NewLine + '\t',
                Environment.NewLine);
        } else {
            selection = selection.Replace(Environment.NewLine,
                Environment.NewLine + '\t');
        }
        if (startNewLineAdded) {
            selection = selection.SubString(Environment.NewLine.Length);
        }
        if (endNewLineRemoved) {
            selection += Environment.NewLine;
        }
        textBox1.SelectedText = selection;
        e.Handled = true;
    }
