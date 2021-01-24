    [Test]
    public async Task Get_ReturnsAllUsers() {
        //Arrange
        var listUsersDto = new ListUsersDto();
        listUsersDto.Users.Add(
               new UserDto()
               {
                   Id = DEFAULT_TRUCK_ID,
                   Color = "White",
                   CreationDate = date,
                   EditDate = date,
                   ManufactureYear = date.Year,
                   ModelYear = date.Year
                }
        );
        _userService.Setup(_ => _.GetAllUsers()).ReturnsAsync(listUsersDto);
        var controller = GetController();
        //Act
        var response = await controller.Get();
        //Assert
        Assert.AreEqual(1, response.Value.Users.Count);
    }
