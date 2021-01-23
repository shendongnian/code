    public class SomeFixture
    {
        private readonly IRepository<SomeEntity> entityRepository;
        private readonly IRepository<SomeThing> thingRepository;
    
        public SomeFixture()
        {
            var entities = new List<SomeEntity>
            {
                BuildEntityForThing(1),
                BuildEntityForThing(1),
                BuildEntityForThing(1),
                BuildEntityForThing(2),
            };
            entityRepository = new FakeRepository(entities);
            
            thingRepository = Substitute.For<IRepository<SomeThing>>();
            thingRepository.GetById(1).Returns(BuildThing(1));
            thingRepository.GetById(2).Returns(BuildThing(2));
        }
    
        public void SomeTest()
        {
            var classUnderTest = new SomeClass(thingRepository, entityRepository);
            
            Assert.AreEqual(classUnderTest.FetchEntitiesForThing(1).Count, 3);
        }
        
        private void SomeOtherTest()
        {
            var classUnderTest = new SomeClass(thingRepository, entityRepository);
            
            Assert.AreEqual(classUnderTest.FetchEntitiesForThing(2).Count, 1);
        }
        private class FakeRepository : IRepository<SomeEntity>
        {
            private readonly List<SomeEntity> items;
            
            public FakeRepository(List<SomeEntity> items)
            {
                this.items = items;
            }
        
            IList<TEntity> Find(Expression<Func<SomeEntity, bool>> criteria)
            {
                // For these purposes, ignore possible inconsistencies 
                // between Linq and SQL when executing expressions
                return items.Where(criteria.Compile()).ToList();
            }
            
            // Other unimplemented methods from IRepository ...
            void Add(SomeEntity entity)
            {
                throw new NotImplementedException();
            }
        }
    }
