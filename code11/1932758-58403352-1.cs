c#
abstract class Animal
{
    public Lion KingOfTheJungle { get; }
    public Animal()
    {
        KingOfTheJungle = (this as Lion) ?? KingOfTheJungle;
    }
}
This still has all but the last problem I mention above though. I would not implement it this way.
You mention that the jungle only ever has one `Lion`. This further suggests that you should make the `Lion` class a singleton. That would look something like this:
c#
abstract class Animal
{
    public static Lion KingOfTheJungle { get; } = Lion.Instance
    public Animal()
    {
        // ...
    }
}
class Lion : Animal
{
    public static Lion Instance { get; } = new Lion();
    private Lion() { }
}
