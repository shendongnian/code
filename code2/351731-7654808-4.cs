    public class Client
    {
        private void DoSomething()
        {
            IController<Product> myController = new ProductController(new ProductFileLogger()); //If you want to be specific
            IController<Product> myController2 = new Controller<Product>(new ProductFileLogger()); //If you want a generic controller and specific logger
            IController<Product> myController3 = new Controller<Product>(new FileLogger<Product>()); //If you want to be as generic as possible
        }
    }
