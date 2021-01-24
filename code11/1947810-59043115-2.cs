    private static string _separator = "/";
    
    private static string _backing = "yyyy{0}MM/dd HH:mm:ss";
    
    public static string DateFormat24H
    {
       get => string.Format(_backing, _separator);
       set => _backing = value;
    }
