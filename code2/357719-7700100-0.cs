    double result;
    if (double.TryParse(txtValue.text, out result))
    {
        // The user typed a valid number.
        // Do something with it (it’s in “result”).
    }
    else
    {
        // The user typed something invalid.
        MessageBox.Show("Please type in a number.");
    }
