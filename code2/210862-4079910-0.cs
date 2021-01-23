    string inputFromRS232Device = GetDeviceInput();
    double value;
    // You need this when converting to the double - not when calling ToString()
    bool success = double.TryParse(
                              inputFromRS232Device, 
                              NumberStyles.Float, 
                              CultureInfo.InvariantCulture, 
                              out value);
