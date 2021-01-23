    static void Main( string[] args )
    {
         string fail = "1234567890";
         string s = "1231231222";
         string mTxt = @"(\d).*\1.*\1.*\1";
         Console.WriteLine( Regex.Match(s,mTxt).Success);
         Console.WriteLine(Regex.Match(fail, mTxt).Success);
    }
