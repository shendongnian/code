    if (ckbSingle.IsChecked.Value)
    {
        if (int.TryParse(txtSingQuan.Text, out int qty) && qty >= singleespresso.DunkinInventory)
        {
            // Input is a valid number and is greater than or equals to stock
            ProductList.Add("Single Espresso");
            // qty variable is accessible in that scope if need be
        }
        else
        {
            // Input is either not a number or lower than stock
            MessageBox.Show("Espresso low in stock.");
        }
    }
