C#
    public static bool security(string UserID, string Action, string[] details)
    public static bool security(string UserID, string Action, string details)
You should write it that way if you're allowed. 
In the version you've got, if you need to make that work, you need to cast it. You can't treat a reference of type object directly as a string or an array, even if the actual object it refers to is actually one of those things. You have to explicitly tell the compiler what you want. In this case, we also want to ask the runtime what the actual type of the referenced object is. 
I don't know what your array might be an array *of*, but any array is non-generic IEnumerable, so we'll use that. 
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
