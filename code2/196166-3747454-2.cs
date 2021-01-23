      private void PriceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            float price;
            if (float.TryParse(priceTextBox.Text, out price))
            {
                tipTextBox.Text = calculate().ToString();
            }
            else
            {
                tipTextBox.Text = "wrong";
            }
       }
