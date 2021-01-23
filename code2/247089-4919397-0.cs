    public interface IUserInputCommandFactory
    {
        IUserInputCommand GetMove();
        IUserInputCommand GetLocate();
        IUserInputCommand GetLookAround();
        IUserInputCommand GetBag();
    }
