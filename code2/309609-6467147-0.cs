public static MatchCollection CheckEmail(string email)
{
    Regex regex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b");          
    MatchCollection matches = regex.Matches(email);
    
    return matches;
}<pre>
