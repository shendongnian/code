    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.Up)
            System.Diagnostics.Debug.WriteLine("Up with control have pressed");
    }
