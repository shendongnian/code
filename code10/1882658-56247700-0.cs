    //Act
    var response = await controller.Get();            
    //Assert
    Assert.IsInstanceOf(typeof(OkObjectResult), response.Result);
    //assert the value within the object result.
    Assert.IsInstanceOf(typeof(ListUsersDto), response.Result.Value);
    //if we reach this far, it is safe to cast
    var dto = response.Result.Value as ListUsersDto;
    Assert.AreEqual(1, dto.Users.Count);
