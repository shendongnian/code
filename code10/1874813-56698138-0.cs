csharp
void Main()
{
   var userFaker = new Faker<User>()
            .RuleFor( u => u.FirstName, f => f.Name.FirstName())
            .RuleFor( u => u.LastName, f => f.Name.LastName().OrNull(f) );
            
   userFaker.Generate(10).Dump();
}
public class User{
   public string FirstName{get;set;}
   public string LastName{get;set;}
}
[![][1]][1]
You can also remove the `ReturnGenderType` helper method and use the `f => f.Person` property instead. Summing it all up, here's how your code cleans up:
csharp
void Main()
{
   var userFaker = new Faker<User>()
    .RuleFor(u => u.Gender,     f => f.Person.Gender.ToString())
    .RuleFor(u => u.BirthDate,  f => f.Date.PastOffset(60, DateTime.Now.AddYears(-18)).Date.ToShortDateString())
    .RuleFor(u => u.FirstName,  f => f.Person.FirstName)
    .RuleFor(u => u.MiddleName, f => f.Name.FirstName(f.Person.Gender).OrNull(f))
    .RuleFor(u => u.LastName,   f => f.Person.LastName)
    .RuleFor(u => u.Salutation, f => f.Name.Prefix(f.Person.Gender));
    
   userFaker.Generate(10).Dump();
}
public class User
{
   public string Gender { get; set; }
   public string BirthDate { get; set; }
   public string FirstName { get; set; }
   public string MiddleName { get; set; }
   public string LastName { get; set; }
   public string Salutation { get; set; }
}
[![][2]][2]
Hope that helps!
  [1]: https://i.stack.imgur.com/iUhZA.png
  [2]: https://i.stack.imgur.com/L5Tje.png
