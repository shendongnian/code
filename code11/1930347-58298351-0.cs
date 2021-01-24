cs
List<Participant> participants = new List<Participant>();
List<Participant2> participant2s = new List<Participant2>();
foreach (var participant in participants)
{
	Participant2 par = participant2s.FirstOrDefault(x => x.Id == participant.Id);
	if (par is null)
	{
		participant2s.Add(new Participant2
		{
			Id = participant.Id,
			Name = participant.Name,
			Adresses = new List<string> { participant.Address }
		});
	}
	else
	{
		par.Adresses.Add(participant.Address);
	}
}
### Notes
I made a few changes, first of all I remove the class `Address` since you only keep an string their anyway. Also you might prefer this solution, since at least IMO it is easier to read. Also if you are getting more complex this would be even more readable.
### Explanation
 1. It is fairly simple, you create a new List of your new Model in this case `Participant2`. 
 2. After that you just loop through all entries in your first list containing the 'old' models.
 3. You check if you already have an entry in your List containing an item with the same Id.
 4. If there is **no** match, it will just create a new item containing the same information.
 5. If there is **a** match, it will add the Address to the entry.
### Important Information
If one of those Lists is a `DbSet<T>` or similar you should be very careful, since this code won't get executed on the Database itself, which can really hurt the performance.
 
