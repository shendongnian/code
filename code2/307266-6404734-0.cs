    public interface IClassDoNotOwn
    {
        event EventHandler<SomeEventArgs> SomeEvent;
    }
    public class ExtendedDonNotOwn : ClassDoNotOwn, IClassDoNotOwn
    {
        
    }
