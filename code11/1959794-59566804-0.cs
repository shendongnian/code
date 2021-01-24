[Command("addrole star")]
public async Task Users()
{
    // The role you want to add.
    var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Star");
    // Get a list of all the guild's users. Not that this may
    // not always work correctly for huge guilds.
    var users = await Context.Guild.GetUsersAsync();
    
    // Iterate through each user and add the role.   
    foreach (IGuildUser user in users)
    {          
        await user.AddRoleAsync(role);
    }
}
