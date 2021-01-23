public class Client
{
    public short ResidesWithCd { get; set; };
    <b>[RequiredIf(nameof(ResidesWithCd), new[] { 99 }, "Resides with other is required.")]</b>
    public string ResidesWithOther { get; set; }
}
Then anytime the **Server** goes to [validate an object][1] (ex. `ModelState.IsValid`, it will check every [`ValidationAttribute`][2] on each property and call [`.IsValid()`][3] to determine validity.  This will work fine, even if <a href="https://msdn.microsoft.com/en-us/library/System.AttributeUsageAttribute" title="System.AttributeUsageAttribute">AttributeUsage</a>.<a href="https://msdn.microsoft.com/en-us/library/System.AttributeUsageAttribute.AllowMultiple" title="System.AttributeUsageAttribute.AllowMultiple">AllowMultiple</a>  is set to true.
