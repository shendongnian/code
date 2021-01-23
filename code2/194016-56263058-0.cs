var result = await controller.SomeAction();
var okObjectResult = Assert.IsType<OkObjectResult>(result);
var results = Assert.IsAssignableFrom<IEnumerable<YourDtoClass>>(okObjectResult.Value);
Assert.NotNull(results);
Assert.All(results, dto => Assert.NotNull(dto.PendingItemCount));
Assert.All(results, dto => Assert.NotNull(dto.ApprovedItemCount));
