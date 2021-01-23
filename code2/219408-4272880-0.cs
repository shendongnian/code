    public static string expando(string input_re) {
 
        // add more chars in s as needed, such as ,.?/|=+_-éñ etc.
        string s = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        string output = "";
   
        Regex exp = new Regex(input_re);
   
        for (int i = 0; i < s.Length; i++) {
            if (exp.IsMatch(s.Substring(i, 1))) {
                output += s[i];
            }
        }
        return output;
    }
