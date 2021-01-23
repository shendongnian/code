    int balance;
    if (Int32.TryParse(txtBalance.Text, out balance)
    {
        // use balance variable
    }
    else
    {
        throw new InvalidOperationException("Wrong input! So on..");
    }
