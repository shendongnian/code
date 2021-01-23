    private void txtText_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key == System.Windows.Input.Key.Tab)
        {
            e.Handled = true;
            if ((System.Windows.Input.Keyboard.Modifiers & System.Windows.Input.ModifierKeys.Shift) != 0)
            {
                var startSel = txtText.Selection.Start;
                var endSel = txtText.Selection.End;
    
                var backwardPosition = txtText.Selection.Start.GetNextInsertionPosition(LogicalDirection.Backward);
                if (backwardPosition != null)
                {
                    txtText.Selection.Select(backwardPosition, txtText.Selection.Start);
                    var c = txtText.Selection.Text;
                    if (c.Equals("\t"))
                    {
                        txtText.Selection.Select(backwardPosition, endSel);
                        txtText.Selection.Text = "";
                    }
                    else
                    {
                        txtText.Selection.Select(startSel, endSel);
                    }
                }
            }
            else
            {
                txtText.Selection.Insert(new Run() { Text = "\t" });
            }
        }
    }
