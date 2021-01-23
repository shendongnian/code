    // interface
    public interface IAdministratorRepository
    {
        Administrator SelectById(Guid _id);
        void Add(Administrator _admin);
    }
    // minimal implementation of admin.  
    public class Administrator
    {
        public Guid Id { get; set; }
        public Administrator(Guid _id)
        {
            Id = _id;
        }
    }
    /// <summary>
    /// For argument's sakes, this is the class under test.  
    /// It's not a mock/fake/stub/whatever; it's the real deal!
    /// </summary>
    public class RealAdministratorRepository : IAdministratorRepository
    {
        private Dictionary<Guid, Administrator> m_items = new Dictionary<Guid, Administrator>();
        
        public Administrator SelectById(Guid _id)
        {
            // no error handling here; keeping it simple
            if(m_items.ContainsKey(_id))
                return m_items[_id];
            return null;
        }
        public void Add(Administrator _admin)
        {
            // No error handling for brevity's sakes
            m_items.Add(_admin.Id, _admin);
        }
    }
    // now, here's a very, very simple happy path test for SelectById using
    // the real implementation of AdministratorRepository
    [TestFixture]
    public class AdministratorRepositoryTests
    {
        private const string AdminId = "a05fd3de-9ae4-4b0b-b560-fd96678d3019";
        private IAdministratorRepository m_repository;
        [SetUp]
        public void PerTestSetUp()
        {
            // no mocks/stubs required.  m_repository is a RealAdministratorRepository
            // because that's our production class and that's what we want to test!
            m_repository = new RealAdministratorRepository();
            m_repository.Add(new Administrator(new Guid(AdminId)));
        }
     
        [Test]
        public void SelectById_WithItemsInRepository_ReturnsCorrectItems()
        {
            // ignore the fact that I'm repeating the same string 3 times; brevity again
            var item = m_repository.SelectById(new Guid(AdminId));
            Assert.That(item, Is.Not.Null);
            Assert.That(item.Id, Is.EqualTo(new Guid(AdminId)));
        }
    }
