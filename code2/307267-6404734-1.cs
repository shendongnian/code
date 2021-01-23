        [Test]
        private void TestMethod()
        {
            var classDoNotOwn = MockRepository.GenerateStub<IClassDoNotOwn>();
            var classUnderTest = new ClassUnderTest();
           
            classDoNotOwn.Raise(dno=> dno.SomeEvent += null, this, EventArgs.Empty);
            ......
            ......
        }
