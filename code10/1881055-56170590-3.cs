     class ChildComparer : EqualityComparer<TestChild>
        {
            public override bool Equals(TestChild b1, TestChild b2)
            {
                if (b1 == null && b2 == null)
                    return true;
                else if (b1 == null || b2 == null)
                    return false;
    
                return (b1.Name == b2.Name);
            }
            public override int GetHashCode(TestChild bx)
            {
                return bx.Name.GetHashCode();
            }
        }
        public class TestChild
        {
            public string Name { set; get; }
        }
        public class TestParent
        {
            public List<TestChild> Child { set; get; }
        }
