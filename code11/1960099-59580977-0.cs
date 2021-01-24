csharp
class Dice
{
    static Random NumberOneToSix = new Random();
    public int value;
    public static int counter = 0;
    public void Throw()
    {
        value = NumberOneToSix.Next(1, 7);
    }
    public void ShowValue()
    {
        counter = counter + 1;
        Console.WriteLine("The value of dice " + counter + " is: " + value);
    }
}
