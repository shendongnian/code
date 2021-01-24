public static class RestrictedCharacterList
{
    public static string GetErrorMessage()
    {
        return " Valid values cannot include the following restricted characters: " + GetList();
    }
}
Added the following to RestrictCharRegExpressAttribute class:
public class RestrictCharRegExpressAttribute : RegularExpressionAttribute
{
    public string AddToRestrictCharErrorMessage { get; set; }
    public override string FormatErrorMessage(string name)
    {
        if (string.isNullOrWhiteSpace(AddToRestrictedCharErrorMessage))
        {
            return base.FormatErrorMessage(name);
        }
        else
        {
            return AddToRestrctCharErrorMessage + " " + RestrictedCharacterList.GetErrorMessage():
        }
    }
}
And then when you want the special character message appended to an existing error message you assign the data attribute like so:
public class User 
{
    public const string IsAlphaRegex = "^[a-zA-Z]*$'
    public const string AlphaErrMsg = "This field can only contain letters.";
    [RestrictCharRegExpress(IsAlphaRegex, AddToRestrictCharErrorMessage = AlphaErrMsg)]
    public string FirstName { get; set; }
}
