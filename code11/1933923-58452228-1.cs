    private void YarnWeightTextbox_TextChanged(object sender, EventArgs e)
    {
            //Check for the empty string. If it is empty then just return
            string weight = YarnWeightTextbox.Text;
            if(String.IsNullOrEmpty(weight))
            {
                return;
            }
    
            //Otherwise convert to integer or to a float as you have
            Int32 val1 = Convert.ToInt32(YarnWeightTextbox.Text);
    
            Class2 ft3 = YarnComboBox.SelectedItem as Class2;
            //When casting using the `as` operator. I make a point of checking for null just
            //in case for some reason it isn't an instance of the class I expect.
            if(ft3 != null)
            {
                //Finally change the 50 to 50.0. This tells the compiler to divide using a float
                //rather than an integer. Dividing 2 integers results in the truncation of the fractional part
                YarnLengthTextbox.Text = Convert.ToString((val1 / 50.0) * ft3.garnlangd1);
            }
    }
