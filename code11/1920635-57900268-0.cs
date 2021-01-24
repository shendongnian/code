        [Test]
        public async Task GetByIdAsync_ShouldReturnRequestedRecord()
        {
            // arrange
            var id = 2;
            var context = this.CreateCheckingDbContext();
            var service = new CheckingService(context.Object);
            var expectedResult = CheckingHelper.GetFakeCheckingData().ToArray()[1];
            // act
            var result = await service.GetByIdAsync(id);
            // assert
            expectedResult.Should().BeEquivalentTo(result);
        }
