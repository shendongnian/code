csharp
class Game
{
    private int playerHp = 100;
    private int monsterHp = 100;
    private int nPotions = 3;
    private readonly Random random = new Random();
    private bool gameOver = false;
    static void ColorPrint(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
    }
    public void Play()
    {
        while (!gameOver)
        {
            RunTurn();
        }
    }
    void RunTurn()
    {
        CheckGameOver();
        if (gameOver) {
            return;
        }
        ColorPrint(String.Format("Monster HP: {0}", monsterHp), ConsoleColor.Red);
        ColorPrint(String.Format("   Your HP: {0}", playerHp), ConsoleColor.Green);
        ColorPrint(String.Format("   Potions: {0}", nPotions), ConsoleColor.Yellow);
        ColorPrint("(A)ttack / (P)otion / anything else to skip your turn?", ConsoleColor.White);
        var command = Console.ReadLine().Trim().ToLower();
        switch (command)
        {
            case "a":
                DoPlayerAttack();
                break;
            case "p":
                DoPlayerPotion();
                break;
            default:
                ColorPrint("You decide to loiter around.", ConsoleColor.White);
                break;
        }
        DoEnemyAttack();
    }
    void CheckGameOver() {
        if (monsterHp <= 0)
        {
            gameOver = true;
            ColorPrint("The monster is slain!", ConsoleColor.White);
        }
        if (playerHp <= 0)
        {
            gameOver = true;
            ColorPrint("You are dead. :(", ConsoleColor.White);
        }
    }
    void DoPlayerAttack()
    {
        var damage = random.Next(1, 10);
        ColorPrint(String.Format("You strike the monster for {0} damage.", damage), ConsoleColor.White);
        monsterHp -= damage;
    }
    void DoPlayerPotion()
    {
        if (nPotions > 0)
        {
            var heal = random.NextDouble() < 0.7 ? random.Next(5, 15) : 0;
            if (heal > 0)
            {
                ColorPrint(String.Format("You heal for {0} HP.", heal), ConsoleColor.Gray);
            }
            else
            {
                ColorPrint("That potion was a dud.", ConsoleColor.Gray);
            }
            playerHp = Math.Min(100, playerHp + heal);
            nPotions--;
        }
        else
        {
            ColorPrint("You rummage through your belongings to find no potions.", ConsoleColor.Gray);
        }
    }
    void DoEnemyAttack()
    {
        var damage = random.Next(1, 10);
        ColorPrint(String.Format("The monster nibbles on you for {0} damage.", damage), ConsoleColor.White);
        playerHp -= damage;
    }
}
