    public static class EventHandlers
    {
        public void EilesNum_Enter(object sender, EventArgs e)
        {
            var txtEilesNum = (TextBox)sender; // Assumed textbox
            txtEilesNum.Clear();
            txtEilesNum.ForeColor = SystemColors.Desktop;
        }
        public void EilesNum_Leave(object sender, EventArgs e)
        {
            var txtEilesNum = (TextBox)sender; // Also assumed textbox
            if(txtEilesNum.Text == "")
            {
                txtEilesNum.ForeColor = SystemColors.InactiveCaption;
                txtEilesNum.Text = "Eil Num";
            }
        }
    }
