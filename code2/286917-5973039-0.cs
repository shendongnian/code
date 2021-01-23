    namespace Website.Tests
    {
        public static class UrlHelperExtender
        {
            public static string Get(this UrlHelper url)
            {
                return "a";
            }
        }
    
        [TestClass]
        public class All
        {
            private class FakeHttpContext : HttpContextBase
            {
                private Dictionary<object, object> _items = new Dictionary<object, object>();
                public override IDictionary Items { get { return _items; } }
            }
    
            private class FakeViewDataContainer : IViewDataContainer
            {
                private ViewDataDictionary _viewData = new ViewDataDictionary();
                public ViewDataDictionary ViewData { get { return _viewData; } set { _viewData = value; } }
            }
    
            [TestMethod]
            public void Extension()
            {
                var vc = new ViewContext();
                vc.HttpContext = new FakeHttpContext();
                vc.HttpContext.Items.Add("wtf", "foo");
                
                var html = new HtmlHelper(vc, new FakeViewDataContainer());
                var url = new UrlHelper(vc.RequestContext);
    
                var xx = url.Get();
    
                Assert.AreEqual("a", xx);
            }
        }
    }
