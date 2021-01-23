        [Test]
        public void Test()
        {
            
            //Mocking is initialized
            MockRepository mockRepository = new MockRepository();
            //Mock of interface is created
            ISomeClass someClass = mockRepository.Stub<ISomeClass>(); 
            //Setup that the method call results in an exception being thrown.
            someClass.Stub(x=> x.DoSomeThing()).Throw(new Exception());
            //Mock is "activated"
            mockRepository.ReplayAll();
            //Here the method is called and it does indeed throw an exception
            Assert.Throws<Exception>(someClass.DoSomeThing);
            
        }
