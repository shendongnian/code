    [TestMethod]
    [Asynchronous]
    public void TestMethod1()
    {
        TestViewModel testViewModel = new TestViewModel();
        bool firstNameChanged = false;
        testViewModel.PropertyChanged +=
            (s, e) =>
                {
                    if (e.PropertyName == "FirstName")
                    {
                        firstNameChanged = true;
                    }
                };
        EnqueueCallback(() => testViewModel.FirstName = "first name");
        EnqueueCallback(() => Assert.IsTrue(firstNameChanged));
        EnqueueTestComplete();
    }
