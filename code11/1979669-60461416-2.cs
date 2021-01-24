c#
public bool Evaluate<TElement>(Func<School, List<TElement>> listSelector)
    where TElement : Person
{
    School school = DbContext.Schools.FirstOrDefault();
    DateTime today = DateTime.Today;
    return listSelector(school)
        // For example, check if today is the birthday of anyone in the selected list
        .Any(person => person.DateOfBirth.Month == today.Month && person.DateOfBirth.Day == today.Day);
}
As @Enigmativity points out, the type constraint is necessary in order to pass much of a meaningful condition to `Any()`, which would also assumes/requires that `Student` and `Teacher` share a common base type, like this...
c#
public abstract class Person
{
    public DateTime DateOfBirth
    {
        get;
    }
}
public class Student : Person
{
}
public class Teacher : Person
{
}
You'd then use it like this...
c#
bool isAnyStudentsBirthday = Evaluate(school => school.Students);
bool isAnyTeachersBirthday = Evaluate(school => school.Teachers);
Note that if you ever want to use `Evaluate()` with some other collection property of `School` that is not specifically `List<>`, or just knowing that all `Any()` needs is an `IEnumerable<>`, you could change the return type of the `Func<>` to something less-restrictive...
c#
Func<School, IList<TElement>>
Func<School, ICollection<TElement>>
Func<School, IEnumerable<TElement>>
