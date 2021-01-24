cs
// example command call: !sample @RandomUser 25
[Command("sample")] 
public async Task ExampleCommand(IUser user, int num)
{
    // Do stuff
    await ReplyAsync($"{user.Mention} has won round {25}");
}
