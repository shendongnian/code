    [TestFixture]
    public class TestFixture
    {
        private ISessionFactory _sessionFactory;
        private ISession _session;
        [SetUp]
        public void Setup()
        {
            var fluentConfig = Fluently.Configure().Database(() => SQLiteConfiguration.Standard.InMemory().Provider<TestConnectionProvider>())
                                       .Mappings(x=>x.FluentMappings.Add<ProductMap>()
                                                                    .Add<ProductWeSellMap>()
                                                                    .Add<ProductWeDontSellMap>());
            var nhConfig = fluentConfig.BuildConfiguration();
            _sessionFactory = fluentConfig.BuildSessionFactory();
            var schema = new SchemaExport(nhConfig);
            schema.Execute(false, true, false);
            
            _session = _sessionFactory.OpenSession();
        }
        [Test]
        public void SomeTest()
        {
            using (var itx = this._session.BeginTransaction())
            {
                var productSold = new ProductWeSell();
                var productNotSold = new ProductWeDontSell();
                _session.Save(productNotSold);
                _session.Save(productSold);
                itx.Commit();
            }
            using (var itx = this._session.BeginTransaction())
            {
                Assert.That(_session.CreateQuery("from ProductWeSell").List(), Has.Count.EqualTo(1));
                Assert.That(_session.CreateQuery("from ProductWeDontSell").List(), Has.Count.EqualTo(1));
                Assert.That(_session.CreateQuery("from IBusinessObject").List(), Has.Count.EqualTo(1));
                Assert.That(_session.CreateQuery("from Product").List(), Has.Count.EqualTo(2));
            }
        }
    }
    public interface IBusinessObject
    {
        Guid Id { get; set; }
    }
    public class Product
    {
        public virtual Guid Id { get; set; }
        public virtual int ProductTypeId { get; set; }
    }
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            this.Id(x => x.Id);
            this.DiscriminateSubClassesOnColumn("ProductTypeId");
        }
    }
    public class ProductWeSell : Product, IBusinessObject
    {
        public const int ProductWeSellTypeId = 1;
    }
    
    public class ProductWeSellMap : SubclassMap<ProductWeSell>
    {
        public ProductWeSellMap()
        {
            this.DiscriminatorValue(ProductWeSell.ProductWeSellTypeId);
        }
    }
  
    public class ProductWeDontSell : Product
    {
        public const int ProductWeDontSellTypeId = 2;
    }
    public class ProductWeDontSellMap : SubclassMap<ProductWeDontSell>
    {
        public ProductWeDontSellMap()
        {
            this.DiscriminatorValue(ProductWeDontSell.ProductWeDontSellTypeId);
        }
    }
