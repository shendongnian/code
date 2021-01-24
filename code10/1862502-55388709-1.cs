    public async Task Should_Return_ProjectsListViewModel() {
        //Arrange
        //...
    
        //Act
        IActionResult actual = await controller.List(2);
    
        //Assert
        ViewResult viewResult = actual as ViewResult;
        viewResult.Should().NotBeNull(); //FluentAssertions
    
        ProjectsListViewModel result = viewResult.ViewData.Model as ProjectsListViewModel;
        result.Should().NotBeNull();
    }
