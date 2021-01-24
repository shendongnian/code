    string savedValue;
    if(String.IsNullOrEmpty(Addresses.Temporary[0].Full_Address_single_line))
    {
        savedValue = Addresses.Home_Permanent[0].Full_Address_single_line;
    }
    else
    {
        savedValue = Addresses.Temporary[0].Full_Address_single_line;
    }
