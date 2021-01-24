    class TestClassComparer : IEqualityComparer<TestClass>
    { 
        public bool Equals(TestClass p1, TestClass p2)
        {
            return p1.name == p2.name && p1.count == p2.count;
        }
        public int GetHashCode(TestClass p)
        {
            return p.count;
        }
    }
    
    var unionlst = lst1.Union(lst2, new TestClassComparer ());
