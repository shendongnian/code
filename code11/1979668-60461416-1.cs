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
As @Enigmativity points out, the type constraint is necessary in order to pass much of a meaningful condition to `.Any()`, which would also assumes/requires that `Student` and `Teacher` share a common base type, like this...
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
