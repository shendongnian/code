        [TestMethod]
        [Tag("Property")]
        public void FirstNameTest()
        {
            bool didFire = false;
            ViewModel = new CustomerViewModel();
            ViewModel.PropertyChanged += (s, e) =>
                                             {
                                                 didFire = true;
                                                 Assert.AreEqual("Firstname", e.PropertyName);
                                                 Assert.AreEqual("Test", ViewModel.Firstname);
                                             };
            ViewModel.Firstname = "Test";
            Assert.IsTrue(didFire);
        }
