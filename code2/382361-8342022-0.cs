public class Model
{
  public Customer Customer { get; set; }
  public double Discount { get; set; }
}
public class SomeController : Controller
{
  private readonly DataAccess dataAccess;
  private readonly ICalculator calculator;
  public SomeController(DataAccess dataAccess, ICalculator calculator)
  {
    this.dataAccess = dataAccess;
    this.calculator = calculator;
  }
  public ActionResult Index(int id)
  {
    var model = new Model();
    model.Customer = this.dataAccess.Get(id);
    model.Discount = this.calculator.Calculate(customer);
    return View(model);
  }
}
