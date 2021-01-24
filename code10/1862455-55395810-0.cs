    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
       try
       {
           string strStockId = comboBox1.Text.ToString();
           string strBasePrice = (comboBox1.SelectedItem as dynamic).basePrice;
           label1.Text = strStockId + " - " + strBasePrice;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
