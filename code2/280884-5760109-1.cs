    public class UserRegistrationInfo
    {
        string DisplayName { get; set; }
        string EmailAddress { get; set; }
    }
    public interface IUserRegistrationView
    {
        void SetDisplayName(string name);
        void SetEmailAddress(string name);
        // ... events for the presenter to hook into.
        void Show(UserRegistrationInfo info);
    }
