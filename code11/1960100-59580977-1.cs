csharp
public class Program
{
    static void Main(string[] args)
    {
        Program DungeonDiceMasters = new Program();
        DungeonDiceMasters.Start();
    }
    void Start()
    {
        // Hold the Dice Counter outside of the scope of the instances
	    int diceCounter = 0;
        Dice d1, d2;
        // Instantiate both dice, while incrementing the diceCounter and passing the value to the ctor
        d1 = new Dice(++diceCounter);
        d2 = new Dice(++diceCounter);
        d1.Throw();
        d2.Throw();
        d1.ShowValue();
        d2.ShowValue();
        Console.Write("\n");
        Console.ReadKey();
        Start();
    }
}
class Dice
{
    static Random NumberOneToSix = new Random();
    // int field which contains the ID/instance number for this instance.
    private readonly int identifier;
    public int value;
    // Constructor which accepts an int parameter
    public Dice(int identifier)
	{
	    this.identifier = identifier;
	}
    public void Throw()
    {
        value = NumberOneToSix.Next(1, 7);
    }
    public void ShowValue()
    {
        Console.WriteLine("The value of dice " + identifier + " is: " + value);
    }
}
You can read more about constructors [here](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors)
