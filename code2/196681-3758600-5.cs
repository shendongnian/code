    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Tab && e.Shift)
        {
            // act like a backspace is pressed
        }
        else if (e.KeyCode == Keys.Back)
        { 
           SendKeys.Send("+{TAB}");   // simualte a shift-tab press
        }
    }
