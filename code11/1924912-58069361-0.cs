[DataContract]
public class HistorySteps
{
    [DataMember(Name = "actualUserDisplayName")]
    public string ActualUserDisplayName { get; set; }
    [DataMember(Name = "actualUserID")]
    public string ActualUserID { get; set; }
    [DataMember(Name = "comments")]
    public string Comments { get; set; }
    [DataMember(Name = "invokerType")]
    public string InvokerType { get; set; }
    [DataMember(Name = "step")]
    public string Step { get; set; }
    [DataMember(Name = "timestampFormatted")]
    public string TimestampFormatted { get; set; }
    [DataMember(Name = "transitionName")]
    public string TransitionName { get; set; }
    [DataMember(Name = "userDisplayName")]
    public string UserDisplayName { get; set; }
    [DataMember(Name = "userID")]
    public string UserID { get; set; }
}
[DataContract]
public class historyList
{
    [DataMember(Name = "historySteps")]
    public List<HistorySteps> HistorySteps { get; set; }
}
[DataContract]
public class MyResponse
{
    [DataMember(Name = "list")]
    public historyList list { get; set; }
}
