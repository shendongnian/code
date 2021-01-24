    private void button_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        if (sender is Button && _buttonToFormDict.ContainsKey(btn))
        {
            Form form = _buttonToFormDict[btn];
            if (!form.IsDisposed && form != null)
            {
                // Show the form if it was not shown
                form.Show();
                // Bring back the form if it was minimized
                if (form.WindowState == FormWindowState.Minimized)
                {
                    form.WindowState = FormWindowState.Normal;
                }
                // Brig to front
                form.BringToFront();
            }
        }
    }
