    using System;
    using NUnit.Framework;
    using FakeItEasy;
    using System.Linq.Expressions;
    
    namespace ClassLibraryTests
    {
        [TestFixture]
        public class IRepositoryTests
        {
            private IRepository CreateSut(Expression<Func<Group, bool>> expression, object result)
            {
                IRepository sut = A.Fake<IRepository>();
                A.CallTo(() => sut.FirstOrDefaultAsync<Group>(expression)).Returns(result);
                return sut;
            }
    
            [Test]
            public void FirstOrDefaultAsyncTests_Office()
            {
                // Arrange    
                BusMessage busMessage = new BusMessage();
                Expression<Func<Group, bool>> expression = x => x.Id == busMessage.Id && x.GroupType == ObjectType.Office;
                object dbOffice = new object();
    
                IRepository repository = this.CreateSut(expression, dbOffice);
    
                // Act
                object obj = repository.FirstOrDefaultAsync<Group>(expression);
    
                //Assert
                Assert.AreEqual(obj, dbOffice);
            }
    
            [Test]
            public void FirstOrDefaultAsyncTests_Country()
            {
                // Arrange    
                BusMessage busMessage = new BusMessage();           
                Expression<Func<Group, bool>> expression = x => x.Id == busMessage.Id && x.GroupType == ObjectType.Country;
                object dbCountry = new object();
    
                IRepository repository = this.CreateSut(expression, dbCountry);
    
                // Act
                object obj = repository.FirstOrDefaultAsync<Group>(expression);
    
                //Assert
                Assert.AreEqual(obj, dbCountry);
            }
        }
    
        public interface IRepository
        {
            object FirstOrDefaultAsync<T>(Expression<Func<T, bool>> expression);
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
