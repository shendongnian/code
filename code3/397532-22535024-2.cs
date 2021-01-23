    private void listBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Up && this.listBox1.SelectedIndex - 1 > -1)
        {
            //listBox1.SelectedIndex--;
        }
        if (e.KeyCode == Keys.Down && this.listBox1.SelectedIndex + 1 < this.listBox1.Items.Count)
        {
            //listBox1.SelectedIndex++;
        }
        if (e.KeyCode == Keys.Enter)
        {
            //Do your task here :)
        }
    }
    private void listBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Enter:
                e.IsInputKey = true;
                break;
        }
    }
