    string s1 = "asdf123";
    string s2 = "asdf127";
    int num1 = FindTrailingNumber(s1);
    int num2 = FindTrailingNumber(s2);
     
    string strBase = s1.Replace(num1.ToString(), "");
    for (int i = num1; i <= num2; i++)
    {
        Console.WriteLine(strBase + i.ToString());
    }
