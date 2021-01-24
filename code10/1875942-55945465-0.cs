/// <param name="validateActivity">A validation method to apply to an activity from the bot.
/// This activity should throw an exception if validation fails.</param>
public TestFlow AssertReply(Action<IActivity> validateActivity, [CallerMemberName] string description = null, uint timeout = 3000)
        
Then we can create our own verification function which can handle assertions.
public Action<IActivity> CheckAttachment(IMessageActivity messageActivity)
{
    // Check if content is the same
    var messageAttachment = messageActivity.Attachments.First();
    // Example attachment
    var adaptiveCardJson = File.ReadAllText(@".\Resources\TicketForm.json");
    var expected = new Attachment()
    {
        ContentType = "application/vnd.microsoft.card.adaptive",
        Content = JsonConvert.DeserializeObject(adaptiveCardJson),
    };
    Assert.AreEqual(messageAttachment.Content.ToString(), expected.Content.ToString());
    return null;
}
The [TestMethod] can then work something like this.
[TestMethod]
public async Task TestSoftwareIssue()
{
    await GetTestFlow()
        .Send(GeneralUtterances.GeneralIssue)
        .AssertReply("Some Response")
        .Send("Some Choice")
        // .AssertReply("")
        .AssertReply(activity => CheckAttachment(activity.AsMessageActivity()))
        .StartTestAsync();
}
