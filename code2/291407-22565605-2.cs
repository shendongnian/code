    [TestFixture]
    public class ExternalTests
    {
        private static string[] TestReplace_args =
            {
                "ab/B/c/ac",
                "HELLO World/Hello/Goodbye/Goodbye World",
                "Hello World/world/there!/Hello there!",
                "hello WoRlD/world/there!/hello there!",
                "///",
                "ab///ab",
                "/ab/cd/",
                "a|b|c|d|e|f/|//abcdef",
                "a|b|c|d|e|f|/|/:/a:b:c:d:e:f:",
            };
        [Test, TestCaseSource("TestReplace_args")]
        public void TestReplace(string teststring)
        {
            var split = teststring.Split("/");
            var source = split[0];
            var oldValue = split[1];
            var newValue = split[2];
            var result = split[3];
            Assert.That(source.Replace(oldValue, newValue, StringComparison.OrdinalIgnoreCase), Is.EqualTo(result));
        }
    }
