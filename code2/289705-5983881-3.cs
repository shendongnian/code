    private void form_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
         List<Char> charList = new List<Char>;
         charList.AddRange(new Char[] { 'a', 'b' ... });
         if (charList.Contains(e.KeyChar)) {}
         else { e.Handled = false; }
    }
