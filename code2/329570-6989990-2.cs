    private void ud_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.K ||
            e.KeyCode == Keys.M)
        {
            e.SuppressKeyPress = true;
            e.Handled = true;
            ud.Value = Math.Max(ud.Minimum, Math.Min(ud.Value * 1000, ud.Maximum));
        }
    }
