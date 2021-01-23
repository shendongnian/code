    [Test]
        public void WhenEngineLightIsOnGetOilChange()
        {
            var carMock = MockRepository.GenerateMock<ICar>();
            carMock.Stub(x => x.EngineLight).Return(true);
    
            Assert.AreEqual(true, carMock.CheckEngineLight()); 
    
            carMock.AssertWasCalled(x => x.GetOilChange()); 
        }
     }
