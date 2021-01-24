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
**EDIT**
The error `The test method expected 1 parameter value, but 2 parameter values were provided.` is caused by `_testData` in class `InvoicesParametersTestData` which returns 2 items. To fix that, your test method should accept two parameters. Like: `GetInvoices_ShouldReturnInvoices(InvoicesParameters iparams, InvoicesParameters iparams2)`.
**But**, this would make for an odd test.
A better way of setting this up, is by using the `InlineData` attribute:
[Theory(DisplayName = "Get Invoices")]
[InlineData(true)]
[InlineData(false)]
public void GetInvoices_ShouldReturnInvoices(bool approved)
{
    var iparams = new InvoicesParameters
    {
        InvoiceType = "P",
        Approved = approved
    };
    var mockService = new Mock<IShopAPService>();
    mockService.Setup(x => x.GetInvoices(iparams))
        .Returns(GetSampleInvoices());
    var controller = new InvoicesController(mockService.Object);
    IHttpActionResult actionResult = controller.GetInvoices(iparams);
    var contentResult = actionResult as OkNegotiatedContentResult<List<Invoice>>;
    Assert.NotNull(contentResult);
    Assert.NotNull(contentResult.Content);
    Assert.Equal(3, contentResult.Content.Count);
}
You won't need the `InvoicesParametersTestData` class anymore.
If you would want to make InvoiceType variable as well, you could do it like this:
[InlineData(true, "P")]
[InlineData(false, "X")]
public void GetInvoices_ShouldReturnInvoices(bool approved, string invoiceType)
