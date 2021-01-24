        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("##vso[task.setvariable variable=sauce]crushed tomatoes test project");
            Assert.Pass();
        }
