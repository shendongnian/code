cs
private class Log
{
    public DateTime LogTime { get; set; }
    public string Result { get; set; }
    public string ItemName { get; set; }
    public Guid? ItemId { get; set; }
    public string ErrorMessage { get; set; }
    public override string ToString()
    {
         return $"{LogTime}, {Result}, {ItemName}, {ErrorMessage}";
    }
}
And than concatenate `logList` into one string using `string.Join`
