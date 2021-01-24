private void minusStock_Btn_Click(object sender, RoutedEventArgs e)
{
    try
    {
        reStock = Int32.Parse(restock_tb.Text);
        if (reStock > 0)
        {
            reStock--;
            restock_tb.Text = reStock.ToString();
            qtyBalance = Int32.Parse(qtyAvailable_tb.Text) - Int32.Parse(restock_tb.Text);
            qtyBalance_tb.Text = qtyBalance.ToString();
        }
    }
    catch
    {
        MessageBox.Show("No item selected to be restock!");
    }
}
**Mistake that I make:**
    qtyBalance = Int32.Parse(qtyBalance_tb.Text) + Int32.Parse(restock_tb.Text);
                    qtyBalance_tb.Text = qtyBalance.ToString();
**It should be done like below:**
    qtyBalance = Int32.Parse(qtyAvailable_tb.Text) - Int32.Parse(restock_tb.Text);
                    qtyBalance_tb.Text = qtyBalance.ToString();
