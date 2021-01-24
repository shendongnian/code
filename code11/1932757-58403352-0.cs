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
