C#
if (Details is System.Collections.IEnumerable ienum)
{
    int i = 0;
    foreach (var s in ienum)
    {
        strDetails += "Detail " + i++ + ": " + s;
    }
}
else if (Details is String s)
{
    strDetails = s;
}
