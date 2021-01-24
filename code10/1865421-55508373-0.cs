    public abstract class AbstractPage
    {
        public AbstractPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);          
        }
    }
    public class PageOne : AbstractPage
    {
        public PageOne(IWebDriver driver) : base(driver)
        {
        }
    }
