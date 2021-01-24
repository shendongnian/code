List<users> userList = getUsers();
public class user
{
   string Name;
   string Country;
   DateTime EnrollmentDate;
}
`List<users>` should be `List<user>`. Next to that, the `Name`, `Country` and `EnrollmentDate` should be marked `public` in order to be accessed.
The same goes for the return type of the `extract unQualifiedUsers`-method (which is invalid because a method name cannot contain any spaces.
`List<user> uqUserList = new List<list>();` doesn't compile either because you are trying to make a List of list (?). `List<user> uqUserList = new List<user>();` will work. 
The line `uList = uList.Except(uqUserList).toList();` is redundant because the `.Where` already does the filtering (and it is incorrect code. `ToList` has a capital T. 
And at last, your filtering logic is incorrect. You want all the users that have been enrolled for less than 5 days.
Fixing all these issues, would result in the following code:
List<user> extractunQualifiedUsers(List<user> uList)
{
    return uList.Where(u => u.Country == "Canada" && WeekDayBetweenDates(u.EnrollmentDate, DateTime.Now) < 5).ToList();
}
public class user
{
    public string Name;
    public string Country;
    public DateTime EnrollmentDate;
}
Piece of advice: Get your code to compile first! Never ever even dare to post code like this again on here.
