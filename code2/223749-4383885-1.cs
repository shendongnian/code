public class LogOnViewModel : ViewModelBase
{
    [DisplayName("User Name")]
    [Required]
    [MailAddress] // This is a custom DataAnnotation I wrote
    public string UserName
    {
        get
        {
                return this.userName;
        }
        set
        {
                this.userName = value;
                this.NotifyPropertyChanged("UserName");
        }
    }
    [DisplayName("Password")]
    [Required]
    public string Password
    {
        get; // etc
        set; // etc
    }
}
