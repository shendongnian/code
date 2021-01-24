csharp
[OneToMany]
public List<Activity> Activities { get; set; }
where `Activity` is an abstract class is not going to work, as it would be very hard to work out what table the data should come from. 
It may construct the tables for `Activity`, `Walk`, `Swim`, `Run` (If you make the `Activity` not abstract) but Sqlite.net Extensions won't be able to create the relationships and thus won't pull back the data.
Personally I wouldn't have the logic of this property in the model that you are persisting, (You may have done this to simplify the question and there is more logic):
csharp
public override double OutputKms { get { return Input * 3; } }
You could refactor to have whatever the multiplier of 3, 5, 3 in `Walk`, `Run`, `Swim` out to property or store an activity type enum in the activity class and not make it abstract like:
csharp
public class Activity
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [ManyToOne(typeof(Day))]
    public Day Day { get; set; }
    [ForeignKey]
    public int DayRefId { get; set; }
    public double Input { get; set; }
    public ActivityType ActivityType { get; set; }
}
public enum ActivityType
{
    Walk,
    Run,
    Swim
}
Another option would be to create different models for the database that are Pocos that map to the more complex app models. Possibly using AutoMapper
