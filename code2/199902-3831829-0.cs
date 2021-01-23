using System.Text.RegularExpressions; 
public string ConvertURLsToHyperlinks(string sInput) 
{ 
    return Regex.Replace(sInput, @"(\bhttp://[^ ]+\b)", @"<a href=""$0"">$0</a>"); 
}
