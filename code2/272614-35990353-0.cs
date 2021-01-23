    public interface IMyThing<T> : IEnumerable<T>
    {
        string Name { get; set; }
        IMyThing<T> GetSub<U>(U key);
    }
    public interface IGenericThing
    {
        string Value { get; set; }
    }
    public class Pet
    {
        public string AnimalName { get; set; }
    }
    public class Unit
    {
        public IEnumerable<Pet> ConvertInput(IMyThing<IGenericThing> input)
        {
            return input.GetSub("api-key-123").Select(x => new Pet { AnimalName = x.Value });
        }
    }
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test1()
        {
            var unit = new Unit();
            Mock<IMyThing<IGenericThing>> mock = new Mock<IMyThing<IGenericThing>>();
            Mock<IMyThing<IGenericThing>> submock = new Mock<IMyThing<IGenericThing>>();
            
            var things = new List<IGenericThing>(new[] { new Mock<IGenericThing>().Object });
            submock.Setup(g => g.GetEnumerator()).Returns(() => things.GetEnumerator());
            mock.Setup(x => x.GetSub(It.IsAny<string>())).Returns(submock.Object);
            var result = unit.ConvertInput(mock.Object);
            Assert.That(result, Is.Not.Null.And.Not.Empty);
            Assert.That(result, Is.Not.Null.And.Not.Empty); // This would crash if the enumerator wasn't returned through a Func<>...
        }
    }
