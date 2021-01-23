    private const string _ID ="CommonIdinHTML";
    [FindsBy(How = How.Id, Using = _ID)]
    private IList<IWebElement> _MultipleResultsByID;
    private const string _ID2 ="IdOfElement";
    [FindsBy(How = How.Id, Using = _ID2)]
    private IWebElement _ResultById;
