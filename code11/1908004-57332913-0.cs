public class Form
{
  private readonly IWebDriver _driver;
  public Form(IWebDriver driver)
  {
     _driver = driver;
  }
  public void Fill(string email)
  {
    // this is where you use the driver to access the form fields and set their contents
  }
}
Then there's the `Main` method that reads the emails from file, creates new forms and fills them with the emails:
public static void Main()
{
   var emails = File.ReadAllLines("emails.txt");
   foreach (var email in emails)
   {
     using (var driver = ... )// todo create new chrome driver instance
     {
        // todo use the driver to navigate to the page where the form is
        var form = new Form(driver);
        form.Fill(email);
     }
   }
}
