    public void Test1()
        {
            var mock = new Mock<ITestClass>();
            mock.Setup(m => m.DoSomething("Whatever"));
            // Assert returns 0
            mock.Setup(m => m.DoSomething("ValidString"));
            // Assert returns arbitrary 12345 - where do I spoof this number?
        }
