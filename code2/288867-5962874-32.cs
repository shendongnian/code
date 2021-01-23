    // Define an interface for handling commands
    public interface IHandler<TCommand>
    {
        void Handle(TCommand command);
    }
    // Define your specific command
    public class MyCommand
    {
        public int SomeInt;
        public SomeEnum SomeEnum;
    }
    // Define your handler for that command
    public class MyCommandHandler : IHandler<MyCommand>
    {
        public void Handle(MyCommand command)
        {
            // here your old execute logic
        }
    }
