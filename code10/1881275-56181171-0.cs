c#
if (item is Potion)
{
    var potion = (Potion) item;
    Console.WriteLine(potion.BonusType);
}
In more recent versionsif c#, you can merge the check with the cast
c#
if (item is Potion potion)
{
    Console.WriteLine(potion.BonusType);
}
Alternatively, switch statement with type check
c#
switch (item)
{
    case Potion potion:
        Console.WriteLine(potion.BonusType);
        break;
}
