    [TestFixture]
    public class GivenCustomCollectionWithTwoElements
    {
        private CustomCollection<MockCustomItem> _customCollection;
        [SetUp]
        public void SetUp()
        {
            _customCollection = new CustomCollection<MockCustomItem>();
            _customCollection.Add(new MockCustomItem());
            _customCollection.Add(new MockCustomItem()); 
        }
        [Test]
        public void CheckLength()
        {
            Assert.That(_customCollection.Items, Is.EqualTo(2));
        }
        [Test]
        public void CheckFirstItemId()
        {
            Assert.That(_customCollection.Items.ElementAt(0).Id, Is.EqualTo(0));
        }
        [Test]
        public void CheckSecondItemId()
        {
            Assert.That(_customCollection.Items.ElementAt(1).Id, Is.EqualTo(1));
        }
        private class MockCustomItem : ICustomItem
        {
            public int Id { get; set; }
            public ICustomCollection<ICustomItem> ParentCollection { get; set; }
        }
    }
