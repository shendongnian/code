    const int minLength = 8;
    const string pattern = ("[@#$%^&+=!]");
    Regex regex = new Regex(pattern);
    public bool Check(string value) => !string.IsNullOrEmpty(value) && 
                             value.Length >= minLength && regex.Match(value).Success;
