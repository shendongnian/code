C#
//  Check for string first, because String is IEnumerable.
if (Details is String s)
{
    strDetails = s;
}
else if (Details is System.Collections.IEnumerable ienum)
{
    int i = 0;
    foreach (var s in ienum)
    {
        strDetails += "Detail " + i++ + ": " + s + "\n";
    }
}
As Alexei reminds me in comments, this should properly be a pair of method overloads, with no casting in either one:
C#
    public static bool security(string UserID, string Action, string[] details)
    public static bool security(string UserID, string Action, string details)
