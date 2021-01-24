csharp
public class Person 
{ 
   public string FirstName { get; set; }
   public string LastName { get; set; }
   public DateTime DateOfBirth { get; set; } 
} 
var people = new List<Person>(); 
/* adding people comes here */
// sorting
var orderedPeople = people.OrderByDescending(person => 
                    person.DateOfBirth);
textBox1.Text = String.Join(" ", 
               from p in orderedPeople 
               select p.FirstName+p.LastName+p.DateOfBirth.ToString("ddMMyyyy")
               );
