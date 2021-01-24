[Authorize]
public class AccountController : Controller
{
  [HttpGet]
  public IActionResult Index()
  {
      var accounts = _accountService.GetAll();
      var models = _mapper.Map<List<AccountDto>>(accounts);
      return View(models);
   }
}
And when I tried to call the controller from the browser, the app initialized DbContext first time due to [Authorize] attribute. And this was done without any HttpContext. So when the application made a call to the DbContext in '_accountService.GetAll()', the DbContext was already instantiated and the Constructor method was not called, therefore, all my private fields remained empty!
So I created a second DbContext class only for authentication/authorization purposes.
public class ApplicationDbAuthContext : IdentityDbContext
{
    public ApplicationDbAuthContext(DbContextOptions<ApplicationDbAuthContext> options) : base(options)
    {
    }
}
Due to this, during the request inside the controller the correct DbContext was instantiated when I made a call and it contained the HttpContext.
I will update my code in the repo to show the changes.
Meanwhile, thanks for all the answers.
        
 
