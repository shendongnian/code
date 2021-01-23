    CustomTextBox ctb = new CustomTextBox();
    ctb.KeyDown += new KeyEventHandler(tb_KeyDown);
    private void tb_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
              //Enter key pressed 
        }
    }
