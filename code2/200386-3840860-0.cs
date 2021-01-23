    public string MyIntegerAsHex
    {
       get { return MyInteger.ToString("X"); }
       set { MyInteger = int.Parse(value, NumberStyles.AllowHexNumber); }
    }
