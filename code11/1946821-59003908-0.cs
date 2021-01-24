csharp
void Main()
{
   int orderIds = 0;
   var users = new Faker<User>()
      .StrictMode(false)
      .RuleFor(o => o.Id, f => orderIds++)
      .RuleFor(o => o.UserName, f => f.Person.FullName) // This needs to be same as the next property
      .RuleFor(o => o.NormalizedUserName, (f, usr) => usr.UserName.ToUpper()); // This should be same but uppercase
      
   users.Generate(3).Dump();
}
public class User{
   public int Id{get;set;}
   public string UserName{get;set;}
   public string NormalizedUserName {get;set;}
}
[![results][1]][1]
  [1]: https://i.stack.imgur.com/T3UTL.png
