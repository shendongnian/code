using System.ComponentModel.DataAnnotations.Schema;
[Table("StudentMaster")]  //write here table name
public class Student
{
   public int Id {get; set;}
   public string Name {get;set;}
   public string College {get;set;}
}
and then create a context class for your database referance
Controller
//here you need to create a context class object
dbcontext _contextclass = new dbcontext(); 
public ActionResult GetData()
{      
    return View(db._contextclass .ToList());
}
