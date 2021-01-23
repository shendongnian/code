    private void cbox_KeyDown(object sender, KeyEventArgs e)
    {
         if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
         {
              OK(cbox.Text);
         }
    }
