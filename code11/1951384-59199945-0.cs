public class PctConverter : ConverterBase
{
    public override object StringToField(string from)
    {
        return decimal.Parse(from.Replace("%", ""));
    }
}
[DelimitedRecord(",")]
[IgnoreFirst]
public class Student
{
    public string Name { get; set; }
    
    [FieldConverter(typeof(PctConverter))]
    public decimal Score { get; set; }
}
