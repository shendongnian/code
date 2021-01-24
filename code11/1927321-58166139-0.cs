    protected void btnUpdate_Click(object sender, EventArgs e){
            string back = drpBack.Text;
            var parsedColor = (KnownColor)Enum.Parse(typeof(KnownColor), back);
            var style = Color.FromKnownColor(parsedColor);
            pnlCard.BackColor = style;
    }
