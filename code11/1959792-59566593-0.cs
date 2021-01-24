public class InvoicesParametersTestData : IEnumerable<object[]>
{
    private readonly List<object[]> _testData = new List<object[]>
    {
        new object[]
        {
            new InvoicesParameters
            {
                InvoiceType = "P", Approved = false
            },
            new InvoicesParameters
            {
                InvoiceType = "P",
                Approved = true
            }
        }
    };
    public IEnumerator<object[]> GetEnumerator() => _testData.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
To be able to use a class with the DataClass attribute, the class has to inherit from `IEnumerable<object[]>`. The specified type has to be an `object`, otherwise xUnit will throw an error.
Because you are implementing `IEnumerable`, you also have to implement the `GetEnumerator()` methods.
