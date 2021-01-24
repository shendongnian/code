    [TestClass]
    public class MathTests
    {
        [DataTestMethod]
        [DynamicData(nameof(ExternalClass.GetData), typeof(ExternalClass), DynamicDataSourceType.Method)]
        public void Test_Add_DynamicData_Method(int a, int b, int expected)
        {
            var actual = MathHelper.Add(a, b);
            Assert.AreEqual(expected, actual);
        }
    }
    public class ExternalClass
    {
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { 1, 1, 2 };
            yield return new object[] { 12, 30, 42 };
            yield return new object[] { 14, 1, 15 };
        }
    }
