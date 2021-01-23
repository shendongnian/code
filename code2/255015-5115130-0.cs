    // By default, KeyDown does not fire for the ARROW keys
    void button1_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Down:
            case Keys.Up:
                if (button1.ContextMenuStrip != null)
                {
                    button1.ContextMenuStrip.Show(button1,
                        new Point(0, button1.Height), ToolStripDropDownDirection.BelowRight);
                }
                break;
        }
    }
    // PreviewKeyDown is where you preview the key.
    // Do not put any logic here, instead use the
    // KeyDown event after setting IsInputKey to true.
    private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Down:
            case Keys.Up:
                e.IsInputKey = true;
                break;
        }
    }
