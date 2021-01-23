        [TestMethod]
        public void TestIndexAction()
        {
            var myAppHost = (MyAppHost)ApplicationHost.CreateApplicationHost(
                typeof(MyAppHost), "/", @"c:\full\physical\path\to\the\mvc\project");
            var view = myAppHost.RenderHomeIndexAction();
            Assert.IsTrue(view.Contains("learn more about"));
        }
