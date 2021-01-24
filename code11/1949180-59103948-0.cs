    public static class TexBoxDecorator
    {
        public static void Decorate(this TextBox tb)
        {
            tb.Enter += tb_Enter;
            tb.Leave += tb_Leave;
        }
    
        private void tb_Enter(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            tb.Clear();
            tb.ForeColor = SystemColors.Desktop;
        }
    
        private void tb_Leave(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.ForeColor = SystemColors.InactiveCaption;
                tb.Text = "Eil Num";
            }
        }
    }
