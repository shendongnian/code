    else if (txtPriceLimit.Text.Contains('.') && char.IsNumber(e.KeyChar))
    {
        int index = txtPriceLimit.Text.IndexOf('.');
        string pennies = txtPriceLimit.Text.Substring(index+1, txtPriceLimit.Text.Length-(index+1));
        pennies=pennies+e.KeyChar.ToString();
        Console.WriteLine("Pennies: " + pennies);
    }
