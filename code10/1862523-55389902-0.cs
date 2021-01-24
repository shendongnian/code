    private void Form1_Load(object sender, EventArgs e)
    {
        TextBox txt_QTY = new TextBox();
        txt_QTY.Location = new Point(100, 100);
        Controls.Add(txt_QTY);
        txt_QTY.Name = "txt_QTY";
        txt_QTY.TextChanged += txt_QTY_TextChanged;
    
        TextBox txt_Price = new TextBox();
        txt_Price.Location = new Point(100, 200);
        Controls.Add(txt_Price);
        txt_Price.Name = "txt_Price";
        txt_Price.TextChanged += txt_Price_TextChanged;
    
    
        TextBox txt_Total = new TextBox();
        txt_Total.Location = new Point(100, 300);
        Controls.Add(txt_Total);
        txt_Total.Name = "txt_Total";
    }
    
    private void txt_QTY_TextChanged(object sender, EventArgs e)
    {
        updateTotal();
    }
    
    private void txt_Price_TextChanged(object sender, EventArgs e)
    {
        updateTotal();
    }
    
    private void updateTotal()
    {
        TextBox txt_QTY = (TextBox)Controls["txt_QTY"];
        TextBox txt_Price = (TextBox)Controls["txt_Price"];
        TextBox txt_Total = (TextBox)Controls["txt_Total"];
    
        if ((txt_QTY.Text != "") && (txt_Price.Text != ""))
        {
            txt_Total.Text = (Convert.ToInt32(txt_QTY.Text) * Convert.ToInt32(txt_Price.Text)).ToString();
        }
    
    }
