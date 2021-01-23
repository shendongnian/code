    public interface IMailMessage
    {
        void Send();
        void SendAsync();
    }
    public interface IUserMailer
    {
        IMailMessage Welcome(WelcomeMailModel model);
    }
