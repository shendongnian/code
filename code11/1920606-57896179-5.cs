           [Test]
        public void WhenMethod2ReturnTrue_ThenDoWork_ShouldReturn_Done()
        {
            Mock<IClass2> class2 = new Mock<IClass2>();
            SomeClass someClass = new SomeClass(class2.Object);
            class2.Setup(x => x.Method2()).Returns(true);
            var doWork = someClass.DoWork();
            Assert.That(doWork,Is.EqualTo("done!"));
        }
        [Test]
        public void WhenMethod2ReturnFalse_ThenDoWork_ShouldReturn_Empty()
        {
            Mock<IClass2> class2 = new Mock<IClass2>();
            SomeClass someClass = new SomeClass(class2.Object);
            class2.Setup(x => x.Method2()).Returns(false);
            var doWork = someClass.DoWork();
            Assert.That(doWork,Is.Empty);
        }
