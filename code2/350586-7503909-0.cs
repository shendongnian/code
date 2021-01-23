    public bool IsButtonYellow;
    private void btn_1_Click(object sender, EventArgs e) {
        if(!IsButtonYellow) {
        btn.BackColor = Color.Yellow;
        IsButtonYellow = true;
        }
        else {
        btn.BackColor = Control.DefaultBackColor;
        IsButtonYellow = false;
        }
    }
