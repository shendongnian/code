public async Task RemoveUsersFromTeam(int teamId, List<long> userIds)
{
    Team existingTeam = await dbContext.Team.Include(x => x.UserTeams).FirstOrDefaultAsync(x => x.Id == teamId);
    foreach (var userId in userIds)
    {
        var userTeam = existingTeam.UserTeams.FirstOrDefault(x => x.UserId == userId);
        if(userTeam != null)
        {
            existingTeam.UserTeams.Remove(userTeam);
        }
    }
    await dbContext.SaveAsync();
}
#Delete By Id#
public async Task RemoveUsersFromTeam(int teamId, List<long> userIds)
{
    Team existingTeam = await dbContext.Team.FirstOrDefaultAsync(x => x.Id == teamId);
    foreach (var userId in userIds)
    {
        var userTeam = new UserTeam { UserId = userId });
        dbContext.UserTeams.Attach(userTeam);
        existingTeam.UserTeams.Remove(userTeam);
    }
    await dbContext.SaveAsync();
}
Option two does not require selecting UserTeams from the database and will be slightly more efficient in that respect. However option one may be more understandable. You should choose which best fits your situation.
Personally I prefer option two, as include will select the whole entity and in some cases that could be a lot more than necessary.
