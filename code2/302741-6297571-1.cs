    try
    {
        if (string.IsNullOrEmpty(sender))
        {
            MessageBox.Show("Please enter a value");
            return 0;
        }
    }
    catch
    {
        //int num = int.Parse(sender);
        return 0;
    }
    return 1;
