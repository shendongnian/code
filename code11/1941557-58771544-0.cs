public enum Status
{
    Deleted= 0,
    Active= 1,
    Passive= 2
}
public class DemoEntity
{
    public int Id { get; set; }
    public Status Status { get; set; }
    [NotMapped]
    public string StatusName
    {
        get { return this.Status.ToString("g"); }
    }
    [NotMapped]
    public int StatusId
    {
        get { return (int)this.Status; }
    }
}
* Don't suffix "Enum" onto your enums - you don't do it for classes (DemoEntityClass?) and Intellisense draws a clear distinction between a class and an enum (for example). Microsoft don't do it (StringSplitOptions, not StringSplitOptionsEnum)
* If your description attributes are the same as your enum name values (as yours are), ToString("g") is a simpler, baked in way of turning the enum name into a string
* Enums are named ints; ints can be cast back and forth to enums willingly. If you try to cast an int to an enum and it is not a member of the enum, it just carries on behaving as the same int value (`((Status)3).ToString()` returns "3");
Consider the library [Enums.Net](https://github.com/TylerBrinkley/Enums.NET) if you're getting heavy into work with enums 
