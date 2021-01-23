        interface IApp
        {
             void App(int i, int j);
        }
        class App : IApp
        {
             // You want constructor to be only with 2 parameters
             public void App(int i, int j){ }
        }
