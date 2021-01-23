static void Main(string[] args)
{
    string strComplete = "stackoverflow is good, I mean, stackoverflow is really good";
    string strSearch = "stackoverflow";
    Console.WriteLine(FormatString(strComplete, strSearch));
    Console.ReadKey();
}
private static string FormatString(string strComplete, string strSearch)
{
    string strSpannedSearch = string.Format("{0}{1}{2}", "<span class=\"normal\">", strSearch, "</span>");
    return strComplete.Replace(strSearch, strSpannedSearch);            
}
