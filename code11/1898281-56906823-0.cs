lang-csharp
public class Portfolio
{
    public string PortfolioName { get; set; }
    public string Description { get; set; }
    public string CreateID { get; set; }
    public string UpdateID { get; set; }
    public Portfolio(string portfolioName, string description, string createID, string updateID)
    {
        PortfolioName = portfolioName;
        Description = description;
        CreateID = createID;
        UpdateID = updateID;
    }
}
It might save you from making a simple typo like that in the future :).
