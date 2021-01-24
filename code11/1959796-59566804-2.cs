[Command("addroll all"), Summary("Usage: !addrole all [rolename]")]
public async Task Users([Remainder] string inputRole = null)
{
	if (inputRole == null)
	{
		await ReplyAsync("Please specify a role");
	}
	else
	{
		try
		{
			var users = await Context.Guild.GetUsersAsync();
			var discordRole = Context.Guild.Roles.FirstOrDefault(x => x.Name == inputRole);
			foreach (IGuildUser user in users)
			{
				await user.AddRoleAsync(discordRole);
			}
		}
		catch (Exception)
		{
			await ReplyAsync("That role does not exist.");
		}
		
	}           
}
