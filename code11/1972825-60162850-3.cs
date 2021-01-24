csharp
public void ProcessPosition()
{
    Console.Write("Enter position: ");
    position = Console.ReadLine();
    if(IsPlayer(position))
    {
        ProcessPlayer();
    }
    else if (IsReferee(position))
    {
        ProcessReferee();
    }
    Console.ReadLine();
}
private bool IsPlayer(string position) => position.ToLower() == "player";
private bool IsReferee(string position) => position.ToLower() == "referee";
private ProcessPlayer()
{
    Console.Write("Enter the score count: ");
    var scoreCount = int.Parse(Console.ReadLine());
    Console.Write("Enter team: ");
    var team = Console.ReadLine();   
    var message = GetPlayerMessage(team, scoreCount);
    Console.WriteLine(message);
}
private string GetPlayerMessage(string team, int scoreCount) => scoreCount < 20 
    ? $"Average job {team}, your score is {scoreCount}";
    : $"Superb job {team}! Your score count is {scoreCount}";
