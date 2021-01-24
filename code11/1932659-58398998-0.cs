    char[] a = "aábdeéðfghiíjklmnoóprstuúvxyýþæö".ToCharArray();
    for (int i = 0; i < a.Length; i++)
    {
        if (i % 2 != 0)
        {
            a[i] = Char.ToUpper(a[i]);
        }
    }
    string result = new string(a);
