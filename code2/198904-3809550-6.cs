    public ActionResult Index() {
        //Create and instance of the new controlle ryou want to handle this request
        SomeController controller = new SomeController();
        controller.ControllerContext = this.ControllerContext;
        return controller.YourControllerAction();
    }
