    public static string test(string value)
    {
        if(string.IsNullOrEmpty(value)) return value;
        var array = value.ToCharArray();
        if (value.Length % 2 == 0)
        {
            array[value.Length / 2 - 1] = Char.ToUpper(array[value.Length / 2 - 1]);
            array[value.Length / 2] = Char.ToUpper(array[value.Length / 2]);
        }
        else
        {
            array[value.Length / 2] = Char.ToUpper(value[value.Length / 2]);
        }
        return new string(array);
    }
