c#
public class viewTraineeModel : PageModel
{
public string[] traineeinfo { get; set; }
...
public viewTraineeModel()
{
traineeinfo=new string[0];
}
