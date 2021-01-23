class WarnCodeValue
{
    public string Meaning
    { get; set; }
    public string ConcatenatedMeaning
    { get; set; }
    public Dictionary<int, WarnCodeValue> ChildNodes 
    { get; set; }
}
