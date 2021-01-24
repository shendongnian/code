[Command("addrole all"), Summary("Adds the Star role to all users")]
public async Task AddRoleStarCommand()
{
    // Gets all the users of the guild. Note that this may not completely
    // work for extremely large guilds (thousands of users).
    var users = await Context.Guild.GetUsersAsync();
    // Gets the role "Star".
    var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Star");
    // Adds the role "Star" to each user in the guild.
    foreach (IGuildUser user in users)
    { 
        await user.AddRoleAsync(role);
    }
}
Remember that in order to use `GetUsersAsync()`, you need an `IGuild`, not a `SocketGuild`. 
public async Task SocketGuildDemoCommand(SocketGuild guild)
{
	// Does not exist, error returned.
	var users await guild.GetUsersAsync();
}
public async Task IGuildDemoCommand(IGuild guild)
{
	// Exists, should work perfectly.
	var users await guild.GetUsersAsync();
}
