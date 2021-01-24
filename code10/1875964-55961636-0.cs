[TestMethod]
public async Task TestFormProcess()
// ...
await GetTestFlow()
    .Send(GeneralUtterances.Access)
    .AssertReply(activity => CheckAttachment(activity.AsMessageActivity(), @".\Resources\TestForms\accessForm.json"))
    .Send(CreateReply(responseOne))
    .AssertReply("Some reply")
    .StartTestAsync();
public IActivity CreateReply(string json)
        {
            return new Activity()
            {
                Value = JsonConvert.DeserializeObject(file),
            };
        }
