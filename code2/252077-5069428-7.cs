class WarnCodeValue
{
    public string Meaning
    { get; set; }
    public string ConcatenatedMeaning
    { get; set; }
    public Dictionary&lt;int, WarnCodeValue> ChildNodes 
    { get; set; }
}
