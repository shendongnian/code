    using System.Text.RegularExpressions;
    
    private string justNumeric(string str)
    {
        Regex rex = new Regex(@"[^\d]");
        return rex.Replace(str,"");
    }
