    public static int Parse(this string s, int defaultValue) {
       int result;
       return Int32.TryParse(s,out result) ? result : defaultValue;
    }
    ...
    int num = "5".Parse(10); //
