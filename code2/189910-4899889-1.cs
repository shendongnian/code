    public class InMemoryRepositoryTests : AbstractRepositoryTests
    {
        [SetUp]
        public override void SetUp()
        {
            _repository = new InMemoryRepository<string>();
        }
    }
