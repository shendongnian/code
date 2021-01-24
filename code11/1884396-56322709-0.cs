    public interface IInterfaceOneAndTwo : IInterfaceOne, IInterfaceTwo
    {
    }
    public interface IInterfaceOne
    {
        void DoOne();
        void DoTwo();
    }
    public interface IInterfaceTwo
    {
        void DoThree();
        void DoFour();
    }
