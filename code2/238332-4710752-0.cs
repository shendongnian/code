    string time = "201555";
    string format = "HHmmss";
    bool ok = false;
    try
    {
        System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;
        DateTime dt = DateTime.ParseExact(time, format, provider);
        if (dt.Hour != null)
        {
            ok = true;
        }
    }
    catch (Exception e)
    {
        //// ok = false; // already setup in initializer above.
    }
