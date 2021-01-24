    [TestClass]
    public class MyTestClass {
        [TestMethod]
        public async Task  Should_Mock_Generic() {
            
            Guid buyCurrencyId = Guid.NewGuid();
            Guid sellCurrencyId = Guid.NewGuid();
            var mockCurrencies3 = new[] { new { Id = buyCurrencyId, Code = "EUR" }, new { Id = sellCurrencyId, Code = "GBP" } };
            
            var mock = new Mock<IGenericRepository<Currency>>();
            SetupGetAs(mock, mockCurrencies3);
            var _currencyRepository = mock.Object;
            var currencies = await _currencyRepository.GetsAs(p => new { p.Id, p.Code }, p => p.Id == sellCurrencyId || p.Id == buyCurrencyId);
            currencies.Should().NotBeNullOrEmpty();
        }
        Mock<IGenericRepository<TEntity>> SetupGetAs<TEntity, TOutput>(Mock<IGenericRepository<TEntity>> mock, IEnumerable<TOutput> source)
            where TEntity : class {
            mock.Setup(x => x.GetsAs(
              It.IsAny<Expression<Func<TEntity, TOutput>>>(),
              It.IsAny<Expression<Func<TEntity, bool>>>(),
              It.IsAny<Func<IQueryable<TEntity>, IQueryable<TEntity>>>())
           )
           .ReturnsAsync(source);
            return mock;
        }
    }
