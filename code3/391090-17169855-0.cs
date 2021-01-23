    public enum TestEnum
    {
        A,
        [Obsolete("Not in use anymore")]
        B,
        [Obsolete("Not in use anymore", true)]
        C,
    }
    public class Class1
    {
        public void TestMethod()
        {
            TestEnum t1 = TestEnum.A; //Works just fine.
            TestEnum t2 = TestEnum.B; //Will still compile, but generates a warning.
            TestEnum t3 = TestEnum.C; //Will no longer compile. 
        }
    }
