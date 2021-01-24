    private void btn_Click(object sender, EventArgs e)
    {
        foreach(Button btn in Controls.OfType<Button>())
            btn.Enabled = true;
        Button button = sender as Button;
        button.Enabled = false;
    }
