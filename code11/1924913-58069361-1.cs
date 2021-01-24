public class HistorySteps
{
    public string actualUserDisplayName { get; set; }
    public string actualUserID { get; set; }
    public string comments { get; set; }
    public string invokerType { get; set; }
    public string step { get; set; }
    public string timestampFormatted { get; set; }
    public string transitionName { get; set; }
    public string userDisplayName { get; set; }
    public string userID { get; set; }
}
public class historyList
{
    public List<HistorySteps> historySteps { get; set; }
}
public class MyResponse
{
    public historyList list { get; set; }
}
