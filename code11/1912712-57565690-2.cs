public class Colony
{
    public int ColonyId {get; set;}
    public string ColonyName {get; set;}
    public List<Tiger> Tigers {get; set;}
}
public class Tiger
{
    public int TigerId {get; set;}
    public string TigerName {get; set;}
    public Colony Colony {get; set;}
    public List<Paw> Paws {get; set;}
}
public class Paw
{
    public int PawId {get; set;}
    public string PawDescription {get; set;}
    public Tiger Tiger {get; set;}
    public List<Toe> Toes {get; set;}
}
public class Toe
{
    public int ToeId {get; set;}
    public Paw Paw {get; set;}
    public int ToeFinger {get; set;}
}
this would be my hierarchy if you will ask me
Colony > Multiple Tigers
Tiger > Multiple Paws
Paw > Multiple Toes
then adding would look like these
var primaryColony = new Colony
{
    ColonyId = 1,
    ColonyName = "First Colony",
    Tigers = new List<Tigers>();
};
var colonies = new List<Colonies>();
//adding primary colony
colonies.Add(primaryColony);
//adding tiger to primary colony via name or you could use ColonyId == 1
colonies.First(c => c.ColonyName == "First Colony")
.Tigers.Add(new Tiger
{
    TigerId = 1,
    TigerName = "Eddy",
    Paws = new List<Paw>();,
    Colony = primaryColony
});
//adding paws to tiger named eddy in colony named primary colony
colonies.First(e => e.ColonyName == "First Colony")
.Tigers.First(r => r.TigerName == "Eddy")
.Paws.Add(new Paw
{
    PawId = 1,
    PawDescription = "right-front",
    Toes = new List<Toes>();,
    Tiger = colonies.First(e => e.ColonyName == "First Colony")
.Tigers.First(r => r.TigerName == "Eddy")
});
//adding toes to right front paw of tiger named eddy in colony named first colony
colonies.First(e => e.ColonyName == "First Colony")
.Tigers.First(r => r.TigerName == "Eddy")
.Paws.First(q => q.PawDescription == "right-front")
.First().Toes.Add(new Toe
{
    ToeId = 1,
    ToeFinger = 1,
    Paw = colonies.First(e => e.ColonyName == "First Colony")
.Tigers.First(r => r.TigerName == "Eddy")
.Paws.First(q => q.PawDescription == "right-front")
});
or if you have a filter, like you want paws to add to TigerName = Eddy
var tigerEddy = colonies.Select(y => new Tiger
{
    TigerId = y.Tigers.FirstOrDefault?.(c => c.TigerName == "Eddy").Select(e => e.TigerId),
    TigerName = y.Tigers.FirstOrDefault?.(c => c.TigerName == "Eddy").Select(e => e.TigerName),
    Colony = y.Tigers.FirstOrDefault?.(c => c.TigerName == "Eddy").Select(e => e.Colony)
    Paws = y.Tigers.FirstOrDefault?.(c => c.TigerName == "Eddy").Select(e => e.Paws)
}.Any(x => x.Tigers.Containes("Eddy").FirstOrDefault();
tigerEddy.Paws.Add(new Paws.....);
then pass it back to colonies with `TigerId` as the reference
