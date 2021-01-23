    [TestMethod]
    public void Index_Shows_When_Not_Logged_In(){
        HomeController controller = new HomeController(_unitOfWork);
        controller.CurrentUserId=0;
        controller.Index();
        //Check your view rendered in here
    }
    [TestMethod]
    public void Some_Other_View_Shows_When_Logged_In(){
        HomeController controller = new HomeController(_unitOfWork);
        controller.CurrentUserId=12; //Could be any value
        controller.Index();
        //Check your view rendered in here
    }
