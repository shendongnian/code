    // verify that IP consists of 4 parts
    if (value.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).Length == 4)
    {
        IPAddress ipAddr;
        if (IPAddress.TryParse(value, out ipAddr))
        {
            // IP is valid
        }
        else
            // invalid IP
    }
    else
        // invalid IP
