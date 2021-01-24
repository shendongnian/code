csharp
[TestMethod]
void TestProcessRaisesEvent() {
    // arrange
    var eventRaiser = new EventRaiserClass();
    var processRequest = new ProcessRequest(eventRaiser);
    var json = default(JObject); // create your json
    Action action = () => processRequest.Process(json);
    // act / assert
    Test.If.RaisesEvent(eventRaiser, "SendEventToClient", action, out Object sender, out EventArgs e);
    Test.If.ReferencesEqual(eventRaiser, sender);
    Test.If.ValuesEqual(e, EventArgs.Empty);
}
You should consider testing `EventRaiserClass` and `ProcessRequest` separately however.
csharp
[TestMethod]
void TestEventRaiserRaisesEvent() {
    // arrange
    var eventRaiser = new EventRaiserClass();
    Action action = () => eventRaiser.RaiseEventForClient();
    // act / assert
    Test.If.RaisesEvent(eventRaiser, "SendEventToClient", action, out Object sender, out EventArgs e);
    Test.If.ReferencesEqual(eventRaiser, sender);
    Test.If.ValuesEqual(e, EventArgs.Empty);
}
[TestMethod]
void TestProcessRaisesEvent() {
    // arrange
    var eventRaiser = new EventRaiserClass();
    var processRequest = new ProcessRequest(eventRaiser);
    var json = default(JObject); // create your json
    Action action = () => processRequest.Process(json);
    // act / assert
    Test.If.RaisesEvent(eventRaiser, "SendEventToClient", action, out Object sender, out EventArgs e);
}
  [1]: https://github.com/MikeLimaSierra/Nuclear.Test
