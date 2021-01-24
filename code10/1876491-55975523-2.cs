    public interface IAction {
        int IntProperty { get; set; }
    }
    var actionMock = new Mock<IAction>()
        .SetupAllProperties()
        .RegisterForJsonSerialization();
    var action = actionMock.Object;
    action.IntProperty = 42;
    Console.WriteLine(JsonConvert.SerializeObject(action));
