    [Fact]
        public async Task Test1()
        {
            // Arrange
            var store = new Mock<IUserStore<IdentityUser>>();
            store.Setup(x => x.FindByIdAsync("123", CancellationToken.None))
                .ReturnsAsync(new IdentityUser()
                {
                    UserName = "test@email.com",
                    Id = "123"
                });
            var mgr = new UserManager<IdentityUser>(store.Object, null, null, null, null, null, null, null, null);
            var controller = new SweetController(mgr);
            // Act
            var result = await controller.GetUser("123");
            // Assert
            Assert.NotNull(result);
            Assert.Equal("123", result.Id);
        }
