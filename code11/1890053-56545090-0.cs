lang-csharp
public class FeedMessageData : IMailData
{
    public FeedMessageData(string username, string subscriptionID, DateTime messageTime)
    {
        MergeData = new Dictionary<string, string>();
        this.feedMessageValue = new FeedMessageValue
        {
             Username = username
           , SubscriptionID = subscriptionID
           , MessageTime = messageTime
        };
    PropertyInfo[] infos = this.feedMessageValue.GetType().GetProperties();
    foreach (PropertyInfo info in infos)
    {
        MergeData.Add(info.Name, info.GetValue(this.feedMessageValue, null).ToString());
    }
    public Dictionary<string, string> MergeData { get; }
}
