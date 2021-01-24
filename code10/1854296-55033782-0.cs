[AttributeUsage(AttributeTargets.Property)]
public class DictionaryRequiredAttribute : ValidationAttribute
{
    public DictionaryRequiredAttribute() : base(() => "The {0} field is required and cannot contain null values.") { }
    public override bool IsValid(object value)
    {
        if (value == null)
        {
            return false;
        }
        if (value is IDictionary dictValue)
        {
            foreach (var key in dictValue.Keys)
            {
                if (dictValue[key] == null)
                {
                    return false;
                }
            }
        }
     
        return true;
    }
}
Based mainly on the implementation of the `RequiredAttribute` found [here][1].
  [1]: https://referencesource.microsoft.com/#System.ComponentModel.DataAnnotations/DataAnnotations/RequiredAttribute.cs,8b8303ed124a453f
