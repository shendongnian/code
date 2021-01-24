 c#
public static void Main(string[] args)
{
    Console.WriteLine("Welcome to Tic-Tac-Toe. Player 1 = X and Player 2 = O");
    string[] arr = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" }; //each char for each square in the grid - defining array
    int player = 1; //player is set to 1 in the beginning to allow for error checking (now set to 2 because of iteration - test)**
    string answer; //user input**
    bool win = false; //win condition**
    bool error = false; //validating user input**
    while (!win) //loop for each player's turn**
    {
        DrawGrid(arr);
        Console.WriteLine("");
        Console.WriteLine("Player {0}'s turn. Enter a number slot", player);
        answer = Console.ReadLine();
        if (!error)
        {
            PlayerMove(answer, arr); //make player move
        }
    }
}
private static void DrawGrid(string[] arr)
{
    Console.WriteLine("|{0}|{1}|{2}|\n|{3}|{4}|{5}|\n|{6}|{7}|{8}|", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], arr[7], arr[8]);
}
private static void PlayerMove(string answer, string[] arr) //make whole new class for this method?**
{
    for (int i = 0; i <= 8; i++) //make player move
    {
        if (answer == arr[i])
        {
            arr[i] = "X";
        }
    }
}
