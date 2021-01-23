    if (boxes[i].Checked == true)
    {
    select += SecondMenuList[i].ToString() + "   :  " + "\t\t" +
        Check[i].ToString("c") + "\r\n";
    Price += Check[i];
    TotalPrice = Price.ToString("c");
    txtTotalPrice.Text = (String.IsNullOrEmpty(txtTotalPrice.Text)?0:(Int32.Parse(txtTotalPrice.Text)+TotalPrice)).ToString();
    }
