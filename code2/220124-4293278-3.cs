    public static string Test_2
    {
        get
        {
            if (_test == null)
            {
                string text1 = _test;
            }
            return (_test = _setting ?? "default");
        }
    }
