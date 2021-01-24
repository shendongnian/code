        private static ActionExecutingContext CreateActionExecutingContextTest()
        {
            Type t = typeof(TestClass);
            var activator = new ViewDataDictionaryControllerPropertyActivator(new EmptyModelMetadataProvider());
            var actionContext = new ActionContext(
                new DefaultHttpContext(),
                new RouteData(),
                new ControllerActionDescriptor()
                {
                    // Either Mock MethodInfo, feed in a fake class that has the attribute you want to test, or just feed in
                    MethodInfo = t.GetMethod(nameof(TestClass.TestMethod))
                });
            var controllerContext = new ControllerContext(actionContext);
            var controller = new TestController()
            {
                ControllerContext = controllerContext
            };
            activator.Activate(controllerContext, controller);
            return new ActionExecutingContext(
                actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                controller);
        }
        public class TestClass
        {
            [MyCustomAttribute]
            public void TestMethod()
            {
            }
        }
