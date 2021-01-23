      private void PriceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            float price;
            if (float.TryParse(damageTextBox.Text, out price))
            {
                tipTextBox.Text = calculate().ToString();
            }
            else
            {
                tipTextBox.Text = "worng";
            }
       }
