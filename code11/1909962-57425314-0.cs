public class EmployeeInformation{
  public int EmployeeInformationId {get;set;}
  public virtual List<EmployeeSalary> EmployeeSalaries {get;set;}
}
public class EmployeeSalary{
  public int EmployeeSalaryId {get;set;}
  public int EmployeeInformationId {get;set;}
  
  [ForeignKey("EmployeeInformationId")]
  public virtual EmployeeInformation EmployeeInformation {get;set;}
}
Then in your Employee Information view, you should have a link or a button that redirect you to add Employee Salaries. This link should contain the Employee Information Id inside an anonymous object.
@Html.Action("AddSalary", new { id = Model.EmployeeeInformationId })
In my example above, I used the action name "AddSalary" there should be a AddSalary method in the Controller to handle this request. So in your EmployeeInformation Controller you should have;
public class EmployeeInformationController:Controller
{
  ...
  public ActionResult AddSalary(int eId)
  {
    new EmployeeSalary es = new EmployeeSalary();
    es.EmployeeInformationId = eId;
    return View(es);
  }
}
Your AddSalary view should use the EmployeeSalary Model, then with the controller action example above, it will auto populate the Employee Information Id with the one passed through the url.
