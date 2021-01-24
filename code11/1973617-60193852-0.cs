Then I should see the following details on the "Stock" page:
    | Field | Value |
    | ...   | ...   |
Then I should see the following details on the "Company Details" page:
    | Field | Value |
    | ...   | ...   |
You will need each of your page objects to implement the same interface, so you can store them in a dictionary and call the `GetText` method on them in the step definition:
public interface IReadOnlyPageModel
{
    string GetText(string key);
}
Then implement this interface in your page models:
public class StockDetailsPage : IReadOnlyPageModel
{
    // stuff specific to the stock details page
    public string GetText(string key)
    {
        // based on key, return text
    }
}
public class CompanyDetailsPage : IReadOnlyPageModel
{
    // stuff specific to the company details page
    public string GetText(string key)
    {
        // based on key, return text
    }
}
Then you will need a dictionary in your step definition class, and of course the step definition:
[Binding]
public class StepDefinitions
{
    private readonly Dictionary<string, IReadOnlyPageModel> detailsPages;
    public StepDefinitions(IWebDriver driver)
    {
        // Or however you get access to the IWebDriver object
        detailsPages = = new Dictionary<string, IReadOnlyPageModel>()
        {
            { "Stock", new StockDetailsPage(driver) },
            { "Company", new CompanyDetailsPage(driver) }
        };
    }
    [Then(@"Then I should see the following details on the ""(.*)"" page:")]
    public void ThenIShouldSeeTheFollowingDetailsOnThePage(string pageName, Table table)
    {
        var page = detailsPages[pageName];
        foreach (var row in table.Rows)
        {
            Assert.That(page.GetText(row["Field"]), Is.EqualTo(row["Value"]));
        }
    }
}
