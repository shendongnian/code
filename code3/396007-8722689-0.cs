    internal class Test
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    internal class LastNameComparer : IEqualityComparer<Test>
    {
        bool IEqualityComparer<Test>.Equals(Test x, Test y)
        {
            if (x.LastName == y.LastName)
                return true;
            return false;
        }
        int IEqualityComparer<Test>.GetHashCode(Test obj)
        {
            return 0; // hashcode...
        }
    }
    private static void Main(string[] args)
    {
        Test objTest = new Test {FirstName = "Perry", LastName = "Joe"};
        Test objTest1 = new Test {FirstName = "Prince", LastName = "Joe"};
        Test objTest2 = new Test { FirstName = "Prince", LastName = "Jim" };
        List<Test> lstTest = new List<Test> {objTest, objTest1, objTest2};
        var distinct = lstTest.Distinct(new LastNameComparer()).ToList();
        foreach (var test in distinct)
        {
            Console.WriteLine(test.LastName);
        }
        Console.Read();
    }
