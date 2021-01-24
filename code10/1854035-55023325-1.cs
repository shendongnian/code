    using System;
    using NUnit.Framework;
    using FakeItEasy;
    
    namespace ClassLibraryTests
    {
        [TestFixture]
        public class IRepositoryTests
        {
            private IRepository CreateSut(Func<Group, bool> func, object result)
            {
                IRepository sut = A.Fake<IRepository>();
                A.CallTo(() => sut.FirstOrDefaultAsync<Group>(func)).Returns(result);
                return sut;
            }
    
            [Test]
            public void FirstOrDefaultAsyncTests_Office()
            {
                // Arrange    
                BusMessage busMessage = new BusMessage();
                Func<Group, bool> func = x => x.Id == busMessage.Id && x.GroupType == ObjectType.Office;
                object dbOffice = new object();
    
                IRepository repository = this.CreateSut(func, dbOffice);
    
                // Act
                object obj = repository.FirstOrDefaultAsync<Group>(func);
    
                //Assert
                Assert.AreEqual(obj, dbOffice);
            }
    
            [Test]
            public void FirstOrDefaultAsyncTests_Country()
            {
                // Arrange    
                BusMessage busMessage = new BusMessage();           
                Func<Group, bool> func = x => x.Id == busMessage.Id && x.GroupType == ObjectType.Country;
                object dbCountry = new object();
    
                IRepository repository = this.CreateSut(func, dbCountry);
    
                // Act
                object obj = repository.FirstOrDefaultAsync<Group>(func);
    
                //Assert
                Assert.AreEqual(obj, dbCountry);
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
