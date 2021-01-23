    [TestFixture]
    public class CustomCollectionTests{
        [Test]
        public void Add_AddTwoItems_ItemsGetsConsecutiveIds() {
            var customItem1 = A.Fake<ICustomItem>();
            var customItem2 = A.Fake<ICustomItem>();
            var cutomCollection = new CustomCollection<ICustomItem>();
            cutomCollection.Add(customItem1);
            cutomCollection.Add(customItem2);
            Assert.AreEqual(1, customItem1.Id);
            Assert.AreEqual(2, customItem2.Id);
        }
    }
    public interface ICustomItem {
        int Id { get; set; }
    }
    public interface ICustomCollection<T> where T : ICustomItem {
        void Add(T t);
    }
    public class CustomCollection<T> : ICustomCollection<T> where T : ICustomItem {
        public List<T> innerList = new List<T>();
        public void Add(T t) {
            // Some logic here...
            innerList.Add(t);
            t.Id = innerList.Count(); // Generate Id
        }
    }
