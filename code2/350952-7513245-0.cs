    string s = "1234";
    if (s.ToCharArray().All(x => Char.IsDigit(x)))
    {
        console.writeline("its numeric");
    }
    else
    {
        console.writeline("NOT numeric");
    }
