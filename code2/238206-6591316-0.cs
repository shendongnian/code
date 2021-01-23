    protected void Button1_Click(object sender, EventArgs e)
    {
        int itemCount;
        decimal itemPrice, itemTotal;
        itemTotal = 0;
        itemCount = 0;
        itemPrice = 0;
        foreach(GridViewRow gridView2Row in gridView2.Rows)
        {
            TextBox tbCount = gridView2Row.Cells[0].Controls[1] as TextBox;
            itemCount = Convert.ToInt32(tbCount.Text);
            itemPrice = Convert.ToDecimal(gridView2Row.Cells[3].Text);
            itemTotal = itemTotal + (itemCount * itemPrice);
        }
        TextBox1.Text = itemTotal.ToString();
    }
