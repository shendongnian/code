    if (totalAmount.ToString().Contains("."))
        {
            string[] b = totalAmount.ToString().Split('.');
            Dollars = b[0].ToString().PadLeft(10, (char)48);
            cents = b[1].ToString().PadRight(2, (char)48).Substring(0, 2);
        }
        else
        {
            Dollars = totalAmount.ToString("F2").PadLeft(10, (char)48);//Necessary change
            cents = "00";
        }
        FormattedTotalAmounts = Dollars + cents; 
