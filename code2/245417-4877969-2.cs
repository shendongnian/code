    public static string Increment(string input)
    {
        var array = input.ToCharArray();
        if (array.Any(c => c < 'A' || c > 'Z'))
            throw new InvalidOperationException();
        for (var i = array.Length-1; i >= 0; i--)
        {
            array[i] = (char)(array[i] + 1);
            if (array[i] > 'Z')
            {
                array[i] = 'A';
                if (i == 0)
                    return 'A' + new string(array);
            }
            else
                break;
        }
        return new string(array);
    }
