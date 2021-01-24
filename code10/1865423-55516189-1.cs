    public class AddEditBlogPostPageObject
    {
        [FindsBy(How = How.Id, Using = "Title")]
        public IWebElement TitleField { get; set; }
        [FindsBy(How = How.Id, Using = "PostDate")]
        public IWebElement DateField { get; set; }
        [FindsBy(How = How.Id, Using = "BodyText")]
        public IWebElement BodyTextField { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(., 'Save Blog Post')]")]
        public IWebElement SaveButton { get; set; }
        private readonly IWebDriver driver;
        public AddEditBlogPostPageObject(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public ViewBlogPostPageObject CreateNewPost(string title, DateTime blogPostDate, string bodyText)
        {
            TitleField.SendKeys(title);
            DateField.SendKeys(blogPostDate.ToShortDateString());
            BodyTextField.SendKeys(bodyText);
            SaveButton.Click();
            return new ViewBlogPostPageObject(driver);
        }
    }
