    public static string ConvertToOneString(params string[] list) 
    {
        string result = String.Empty;
        for ( int i = 0 ; i < list.Length ; i++ )
        {
            result += list[i];
        }
        return result;
    }
