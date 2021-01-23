    public static class MyMessageBuilder
    {
        public static void Build(IMyMessage message) { /* ... */ }
    }
    public class ClassThatTestsMyMessageBuilder
    {
        public void CallCodeThatBuildsMessage()
        {
            var message = Test.CreateInstance<IMyMessage>(MyMessageBuilder.Build);
            //Verify message contents
        }
    }
