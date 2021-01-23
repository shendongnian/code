    private void lookUpEdit1_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            MessageBox.Show((e.OriginalSource as SLTextBox).Text);
        }
    }
