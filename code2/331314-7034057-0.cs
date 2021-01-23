    [Test]
    public void MyTestAction_Redirects_To_MyOtherAction()
    {
      var controller = new MyController();
      
      var result = (RedirectToRouteResult)controller.MyTestAction();
    
      Assert.That(result.RouteValues["action"], Is.EqualTo("MyOtherAction");
      Assert.That(result.RouteValues["controller"], Is.EqualTo("MyOtherController");
    }
