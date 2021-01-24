    using System;
    using NUnit.Framework;
    using FakeItEasy;
    
    namespace ClassLibraryTests
    {
        [TestFixture]
        public class IRepositoryTests
        {
            [Test]
            public void FirstOrDefaultAsyncTests()
            {
                // Arrange    
                BusMessage busMessage = new BusMessage();
                object dbOffice = new object();
                object dbCountry = new object();
                Func<Group, bool> d1 = x => x.Id == busMessage.Id && x.GroupType == ObjectType.Office;
                Func<Group, bool> d2 = x => x.Id == busMessage.Id && x.GroupType == ObjectType.Country;
    
                IRepository repository = A.Fake<IRepository>();
                A.CallTo(() => repository.FirstOrDefaultAsync<Group>(d1)).Returns(dbOffice);
                A.CallTo(() => repository.FirstOrDefaultAsync<Group>(d2)).Returns(dbCountry);
    
                // Act
                object obj1 = repository.FirstOrDefaultAsync<Group>(d1);
                object obj2 = repository.FirstOrDefaultAsync<Group>(d2);
    
                //Assert
                Assert.AreEqual(obj1, dbOffice);
                Assert.AreEqual(obj2, dbCountry);
            }
        }
    
        public interface IRepository
        {
            object FirstOrDefaultAsync<T>(Func<T, bool> func);
        }
    
        public class Group
        {
            public ObjectType GroupType { get; set; }
            public int Id { get; set; }
        }
    
        public class BusMessage
        {
            public int Id { get; set; }
        }
    
        public enum ObjectType
        {
            Office,
            Country
        }
    }
