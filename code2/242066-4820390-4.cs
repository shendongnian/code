    public class SomePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IDataProvider provider = ProviderFactory.GetProvider();
            provider.Foo();
        }
    }
