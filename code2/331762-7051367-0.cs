    public interface IMyPrincipal : IPrincipal
    {
        Guid UserId { get; }
        string EmailAddress { get; }
    }
