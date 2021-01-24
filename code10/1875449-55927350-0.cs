cs
//I'm doing this as a command, but the logic can be implemented wherever you decide.
[Command("region")]
[Remarks("Let's pretend my module has access to a singleton instance of random")]
public async Task ChangeRegion()
{
    //Get a collection of all available voice regions 
    //Exclude the region we are currently in
    var voiceRegions = Context.Client.VoiceRegions.Where(r => !r.Id.Equals(Context.Guild.VoiceRegionId));
    
    //Select a random new region
    var newRegion = voiceRegions(random.Next(voiceRegions.Count));
    //Update the RegionId property for the guild.
	await Context.Guild.ModifyAsync(prop => prop.RegionId = newRegion.Id)
    await ReplyAsync($"Region updated to {newRegion.Name}: {newRegion.Id}");
}
