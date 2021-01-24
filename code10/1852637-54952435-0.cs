new Email().Send(from, to, subject, body, true);
whereas a better approach would be to supply an `IEmail` in the constructor:
    IEmail _email;
    //Constructor
    public ExampleService(IEntityModel model, IEmail email) : base(model) 
    { 
        _email = email;
    }
then use this later:
    public void SendEmailForAlarm(string email, Alarm alarm)
    {
        _email.Send(from, to, subject, body, true);
    }
you can then inject your `Mock<IEmail>` into your `ExampleService` and check that it was called as appropriate.
If it's difficult/impossible to set up DI properly for constructor injection, then you *could* have a public property which allows you to *replace* the IEmail in the class with another for Unit testing, but this is a bit messier:
public class ExampleService
{
    private IEmail _email = null;
    public IEmail Emailer
    {
        get
        {
            //if this is the first access of the email, then create a new one...
            if (_email == null)
            {
                _email = new Email();
            }
            return _email;
        }
        set
        {
            _email = value;
        }
    }
    ...
    public void SendEmailForAlarm(string email, Alarm alarm)
    {
        //this will either use a new Email() or use a passed-in IEmail
        //if the property was set prior to this call....
        Emailer.Send(from, to, subject, body, true);
    }
}
Then in your test:
    //Arrange
    var mockEmail = new Mock<IEmail>();         //NEW
    var mockContext = new Mock<IEntityModel>();     
    var mockSetAlarm = new Mock<DbSet<Alarm>>();
    var service = new ExampleService(mockContext.Object);
    //we set the Emailer object to be used so it doesn't create one..
    service.Emailer = mockEmail.Object;
if having a `public` property like this is a problem you could perhaps make it `internal` and use `internalsvisibleto` (google) to make it visible in your test project (though this would still be visible to other classes in the project containing the Service itself)..
