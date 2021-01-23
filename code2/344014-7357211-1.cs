    private string[] splitIntoAry(string str)
    {
        string[] temp = new string[(int)Math.Ceiling((double)str.Length / 3)];
        while (str != string.Empty)
        {
            temp[(int)Math.Ceiling((double)str.Length / 3) - 1] = str.Substring(str.Length - Math.Min(str.Length, 3));
            str = str.Substring(0, str.Length - Math.Min(str.Length, 3));
        }
        return temp;
    }
