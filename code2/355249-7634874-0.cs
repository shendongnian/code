    [Test]
    public void Page1_Post_IfallDataOK_ShouldSaveAndReturnPage2()
    {
      var controller = new HomeController(repository.Object); //repository is: Mock<IRepository>
      var result = controller.Page1(new MyModel() {MyValue = "test"});
      Assert.IsInstanceOfType(typeof(RedirectToRouteResult), result);
      var redirect = (RedirectToRouteResult)result;
      Assert.AreEqual("Page2", redirect.RouteValues["action"]);
      repository.Verify(x => x.Save(It.IsAny<MyModel>()), Times.Once());
    }
