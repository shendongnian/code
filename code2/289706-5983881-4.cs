    private void form_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
         if (char.IsLetterOrDigit(e.KeyChar)) {}
         else { e.Handled = false; }
    }
