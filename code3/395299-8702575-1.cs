    private void button_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.IsInputKey = true;
        }
    }
