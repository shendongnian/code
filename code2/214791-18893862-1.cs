        public void Justification()
        {
            var foo = new Mock<IFoo>(MockBehavior.Loose);
            foo.Setup(x => x.Fizz());
            var objectUnderTest = new ObjectUnderTest(foo.Object);
            objectUnderTest.DoStuffToPushIntoState1(); // this is various lines of code and setup
            foo.Verify(x => x.Fizz());
            // Some cool stuff
            
            using (Sequence.Create())
            {
                foo.Setup(x => x.Fizz()).InSequence(Times.Never())
                objectUnderTest.DoStuffToPushIntoState2(); // more lines of code
            }
        }
