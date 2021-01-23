    interface IActivation
    {
        double func(double inputput);
    }
    public static class ActivationFactory
    {
        IActivation GetImplA()
        {
            return new ImplA();
        }
        IActivation GetImplB()
        {
            return new ImplB();
        }
    }
    class ImplA : IActivation { }
    class ImplB : IActivation { }
