       [Test]
       public void ShouldCreateBusinessOBjectWithPropertiesInitializedByDtoValues()
       {
          // ARRANGE
          // - create mock of the IRepository
          // - create dto
          // - setup expectations for the IRepository.Add() method
          //   to check whether all property values are the same like in dto   
          var repositoryMock = MockRepository.GenerateMock<IRepository>();
          var dto = new Dto() { ... };
          BusinessObject actualBusinessObject = null;
          repositoryMock.Expect(x => x.Add(null)).IgnoreArguments().WhenCalled(
            (mi) => 
            {
                actualBusinessObject = mi[0] as BusinessObject;            
            }).Repeat().Any();
    
          // ACT
          // - create service layer, pass in repository mock
          // - execute svc.ProcessDto(dto)     
          var serviceLayerContext = new ServiceLayerContext(repositoryMock);
          serviceLayerContext.ProcessDto(dto);
    
          // ASSERT
          // - check whether expectations are passed
          Assert.IsNotNull(actualBusinessObject);
          Assert.AreEqual(dto.Id, actualBusinessObject.Id);
          ...
       }
