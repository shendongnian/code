    internal static class TestData
    {
        public static IList<T> Get<T>(int count = 10)
        {
            // I'm using NBuilder here to generate test data quickly.
            // Use your own logic to create your test data.
            return Builder<T>.CreateListOfSize(count).Build();
        }
    }
Now, all your test classes can leverage this to get the same set of test data. So, in your data class, you would do something along the lines of
    public class DataClass
    {
        public static IEnumerable<object[]> Data()
        {
             return new List<object[]>
                    {
                        new object[] { TestData.Get(), this.ExpectedResult() }
                    };
        }
    } 
Now you can follow through with your original approach:
    [Theory]
    [MemberData(nameof(DataClass.Data), MemberType = typeof(DataClass))]
    public void TestValidConfig(Data input, Configuration expected)
    {
        ...
    }
If your tests don't mutate the input data, You can collect them into a fixture and inject the input data through constructor. This would speed up the tests since you don't have to generate the input data per test. Check out [shared context](https://xunit.github.io/docs/shared-context) for more information.
