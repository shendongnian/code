    [InterfaceSpecification]
    public class IFooTests : AppliesToAll<IFoo>
    {
        [Test]
        public void can_add_two_numbers()
        {
            Assert.AreEqual(5, subject.Add(2, 3));
        }
    }
