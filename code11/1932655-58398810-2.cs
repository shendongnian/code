    String a = ("aábdeéðfghiíjklmnoóprstuúvxyýþæö");
    for (int i=0; i<a.Length; i++)
    {
        if (n % 2 == 0)
        {
             a = a.Substring(0, i) + a.Substring(i, 1).ToUpper() + a.Substring(i);
        }
    }
