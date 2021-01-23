    public static void setPrice(Double? value)
    {
        if (value != null) {
            this.TextBoxPrice.Text = Math.Round(value.Value, 2).ToString();
        } else {
            this.TextBoxPrice.Text = "No Price";   
        }
    }
