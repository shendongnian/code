    int controlCounts = 0;
    private void addControls_Click(object sender, EventArgs e)
    {
        controlCounts++;
        TextBox txt_QTY = new TextBox();
        txt_QTY.Location = new Point(100 * controlCounts, 100);
        Controls.Add(txt_QTY);
        txt_QTY.Name = "txt_QTY" + controlCounts;
        txt_QTY.TextChanged += txt_QTY_TextChanged;
        TextBox txt_Price = new TextBox();
        txt_Price.Location = new Point(100 * controlCounts, 200);
        Controls.Add(txt_Price);
        txt_Price.Name = "txt_Price" + controlCounts; ;
        txt_Price.TextChanged += txt_Price_TextChanged;
        TextBox txt_Total = new TextBox();
        txt_Total.Location = new Point(100 * controlCounts, 300);
        Controls.Add(txt_Total);
        txt_Total.Name = "txt_Total" + controlCounts;
    }
    private void txt_QTY_TextChanged(object sender, EventArgs e)
    {
        TextBox txt_QTY = (TextBox)sender;
        string index = txt_QTY.Name.Substring("txt_QTY".Length);
        updateTotal(index);
    }
    private void txt_Price_TextChanged(object sender, EventArgs e)
    {
        TextBox txt_Price = (TextBox)sender;
        string index = txt_Price.Name.Substring("txt_Price".Length);
        updateTotal(index);
    }
    private void updateTotal(string index)
    {
        TextBox txt_QTY = (TextBox)Controls["txt_QTY" + index];
        TextBox txt_Price = (TextBox)Controls["txt_Price" + index];
        TextBox txt_Total = (TextBox)Controls["txt_Total" + index];
        if ((txt_QTY.Text != "") && (txt_Price.Text != ""))
        {
            txt_Total.Text = (Convert.ToInt32(txt_QTY.Text) * Convert.ToInt32(txt_Price.Text)).ToString();
        }
    }
