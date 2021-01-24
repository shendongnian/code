    [TestClass]
    public class UnitTest1
    {
        private Person _person;
        [TestMethod]
        public void TestSwappingPerson()
        {
            _person = new Person { FirstName = "Scott" };
            var newPerson = new Person() { FirstName = "Bob" };
            SwapPersonFour(ref newPerson);
            Assert.AreEqual("Bob", _person.FirstName);
        }
        public void SwapPersonFour(ref Person newPerson)
        {
            LocalSwap(ref _person, ref newPerson);
            void LocalSwap(ref Person oldPerson, ref Person localNewPerson)
            {
                oldPerson = localNewPerson;
            }
        }
    }
