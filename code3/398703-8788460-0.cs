    interface IJob 
    {
      ICommand Command { get; }
    }
    public class JobA : IJob
    {
      private readonly ICommand _command = new CommandA();
      public ICommand Command { get { return _command; } }
    }
