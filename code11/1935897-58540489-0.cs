    [Test]
    public async Task ReturnBadRequestIfNullRequiredProperty() {
        // Assemble
        var services = ConversionsControllerContext.GivenServices();
        var controller = services.WhenCreateController();
        controller.ModelState.AddModelError("Name","Name required"); //<-- Invalidate model state
        //...other desired errors.
         
        // Act
        var actionResult = await controller.CreateAsync(new ConversionViewModel());
        var badRequestResult = actionResult as BadRequestResult;
        // Assert
        badRequestResult.Should().NotBeNull();
        badRequestResult?.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
    }
