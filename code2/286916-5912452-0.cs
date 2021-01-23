    public interface IUrlHelper 
    {
        public string Action(string actionName);
        // Add other methods you need to use in your extension method.
    }
    public class UrlHelperAdapter : IUrlHelper
    {
        private readonly UrlHelper urlHelper;
        public UrlHelperAdapter(UrlHelper urlHelper)
        {
            this.urlHelper = urlHelper;
        }
        string IUrlHelper.Action(string actionName)
        {
            return this.urlHelper.Action(actionName);
        }
    }
    public static class UrlHelperExtension
    {
        public static string GetContent(this UrlHelper url, string link, bool breakCache = true)
        {
            return GetContent(new UrlHelperAdapter(url), link, breakCache); 
        }
    
        public static string GetContent(this IUrlHelper url, string link, bool breakCache =     true)
        {
            // Do the real work on IUrlHelper
        }
    }
    [TestClass]
    public class HelperTestSet
    {
        [TestMethod]
        public void GetContentUrl()
        {
            string expected = "...";
            IUrlHelper urlHelper = new UrlHelperMock();
    
            string  actual = urlHelper.GetContent("...", true);
            
            Assert.AreEqual(expected, actual);
        }
    }
