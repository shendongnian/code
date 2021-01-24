C#
namespace API.Models
{
  public class UpdateUser
  {
    public string Surname { get; set; }
    public string Name { get; set; }
    ...
  }
}
namespace Domain.Commands
{
  public class UpdateUser:ICommand
  {
    [JsonConstructor]
     public UpdateUser(Guid id, string surname, string name, string middleName, string department, string position, string adAccount, string email, string userName, string password)
     {
       Id = id;
       Surname = surname;
       Name = name;
       MiddleName = middleName;
       Department = department;
       Position = position;
       AdAccount = adAccount;
       Email = email;
       UserName = userName;
     }
     public Guid Id { get; }
...
  }
}
and in the controller
namespace API.Controllers
{
  public class UserController
  {
    [HttpPut("{id}")]
    [JwtAuth(Roles.Administrator)]
    public async Task<ActionResult> Put(Guid id, API.Models.UpdateUser command)
    {
      //Send command to RabbitMQ(serialized)
      //Id binded before sending but after construct in service ID is missing
      var cmd = new Domain.Commands.UpdateUser( id, command.Surname, command.Name, ... );
      await SendAsync(cmd);
      return Accepted();
    }  
  }
}
The Domain.Commands can be placed inside a class library and used by API and Microservice as well.
