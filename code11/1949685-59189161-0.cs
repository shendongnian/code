        private string GetPathHere(string actionName)
        {
            var host = Program.CreateWebHostBuilder(new string[] { }).Build();
            host.Start();
            IActionDescriptorCollectionProvider provider = (host.Services as ServiceProvider).GetService<IActionDescriptorCollectionProvider>();
            return provider.ActionDescriptors.Items.First(i => (i as ControllerActionDescriptor)?.ActionName == actionName).AttributeRouteInfo.Template;
        }
        [TestMethod]
        public void OkTestShouldBeFine()
        {
            var path = GetPathHere(nameof(ValuesController.OkTest)); // "api/Values" in my case
        }
