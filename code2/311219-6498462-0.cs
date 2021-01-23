    public static string KeycodeToChar(int keyCode)
    {
        Keys key = (Keys)keyCode;
         
        switch (key)
        {
            case Keys.Add:
                return "+";
            case Keys.Subtract:
                return "-"; //etc...
            default:
                return key.ToString();
        }
    }
