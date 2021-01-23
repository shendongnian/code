    [TestClass()]
    public class ComparerTest
    {
        [TestMethod()]
        public void Matches_With_Wildcard()
        {
            char[] values = {'0', '1', '1', '1'};
            Assert.IsTrue(Comparer.AreEqualOrZero(values));
        }
        [TestMethod()]
        public void Matches_With_No_Wildcard()
        {
            char[] values = {'1', '1', '1', '1'};
            Assert.IsTrue(Comparer.AreEqualOrZero(values));
        }
        [TestMethod()]
        public void Matches_With_Only_Wildcards()
        {
            char[] values = {'0', '0', '0'};
            Assert.IsTrue(Comparer.AreEqualOrZero(values));
        }
        
        [TestMethod()]
        public void Matches_With_Zero_Length()
        {
            char[] values = {};
            Assert.IsTrue(Comparer.AreEqualOrZero(values));
        }
        
        [TestMethod()]
        public void Matches_With_One_Element()
        {
            char[] values = {'9'};
            Assert.IsTrue(Comparer.AreEqualOrZero(values));
        }
        
        [TestMethod()]
        public void Matches_With_One_Wildcard_And_Nothing_Else()
        {
            char[] values = {'0'};
            Assert.IsTrue(Comparer.AreEqualOrZero(values));
        }
        
        [TestMethod()]
        public void Does_Not_Match_On_NonEqual_Sequence_No_Wildcard()
        {
            char[] values = {'1', '2', '1', '1'};
            Assert.IsFalse(Comparer.AreEqualOrZero(values));
        }
        
        [TestMethod()]
        public void Does_Not_Match_On_NonEqual_Sequence_With_Wildcard()
        {
            char[] values = {'1', '2', '1', '0'};
            Assert.IsFalse(Comparer.AreEqualOrZero(values));
        }
    }
