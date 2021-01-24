csharp
    static void Main(string[] args)
    {
        Program DungeonDiceMasters = new Program();
        DungeonDiceMasters.Start();
    }
    void Start()
    {
        DiceRoller dr = new DiceRoller();
        dr.Throw();
        dr.ShowValue(true);
        dr.Throw();
        dr.ShowValue();
        Console.Write("\n");
        Console.ReadKey();
        Start();
    }
class DiceRoller
{
    static Random NumberOneToSix = new Random();
    public int value = 0;
    public int counter = 0;
    private bool diceThrown = false; //add throw tracker to avoid losing dice rolls
    public void Throw()
    {
        value = NumberOneToSix.Next(1, 7);
        diceThrown = true; //dice have been thrown
    }
    public void ShowValue(bool startOver = false) //optional parameter to reset dice counter
    {
        if(startOver) //if param set, reset counter
            counter = 0;
        counter = counter + 1;
        if(!diceThrown) // self-explanatory
            Throw(); //internal call to method to throw dice
        Console.WriteLine("The value of dice " + counter + " is: " + value);
        diceThrown = false; //reset dice throw tracker
    }
}
I added some comments to hopefully explain what's going on and why I made the edits I did. Hope this helps!
