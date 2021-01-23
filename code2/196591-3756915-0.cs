    using System;
    using NUnit.Framework;
    using StructureMap;
    
    namespace SMTest2
    {
        public interface IRepository<T> {}
        public class AbnormalRepository<T,T2> : IRepository<T>{ }
    
        [TestFixture]
        public class TestOpenGeneric
        {
            private IContainer _container   ;
    
            [SetUp]
            public void DescribeContainer()
            {
                _container = new Container(cfg => 
                    cfg.For(typeof (IRepository<>)).Use(ctx => new AbnormalRepository<String, int>()));
            }
    
            [Test]
            public void TestItWorks()
            {
                var stringVector = _container.GetInstance(typeof (IRepository<>));
                Assert.IsInstanceOf<AbnormalRepository<String,int>>(stringVector);
            }
        }
    }
