[Command("addroll all"), Summary("Usage: !addrole all [rolename]")]
public async Task Users([Remainder] string inputRole = null)
{
    // If the user does not specify a role
	if (inputRole == null)
	{
		await ReplyAsync("Please specify a role");
	}
	else
	{
		try
		{
            // Get a list of the guild's users. Not that this may not always
            // work and very large guilds due to Discord's own limitations.
			var users = await Context.Guild.GetUsersAsync();
            // Conver the role input into an actual role.
			var discordRole = Context.Guild.Roles.FirstOrDefault(x => x.Name == inputRole);
             
            // Add the role to each user in the guild.
			foreach (IGuildUser user in users)
			{
				await user.AddRoleAsync(discordRole);
			}
		}
		catch (Exception)
		{
            // If the role doesn't exist send an error message.
			await ReplyAsync("That role does not exist.");
		}
		
	}           
}
