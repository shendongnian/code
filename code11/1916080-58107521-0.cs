When I Perform POST Operation for "/example/"
    | Field        | Value  |
    | answerValue1 | ...    |
    | answerValue2 | ...    |
    | countryCodes | AD, AF |
    | cash         | ...    |
In your step definition:
var example = table.CreateInstance<ExampleRow>();
// use example.GetCountryCodes();
And the ExampleRow class to parse the table into an object:
public class ExampleRow
{
    public string AnswerValue1 { get; set; }
    public string AnswerValue2 { get; set; }
    private string[] countryCodes;
    public string CountryCodes
    {
        get => string.Join(", ", countryCodes);
        set => countryCodes = value.Split(", ");
    }
    
    public string[] GetCountryCodes()
    {
        return countryCodes;
    }
}
