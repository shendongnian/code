c#
var expectedList = new List<EventModel>()
            {
                new EventModel()
                {
                    Id = 0
                }
            };
            {
                var repositoryMock = new Mock<IGetRepository<EventModel>>();
                repositoryMock
                    .Setup(items => items.Get(It.IsAny<Func<IQueryable<EventModel>, IOrderedQueryable<EventModel>>>()))
                    .Returns(() => expectedList);
            }
