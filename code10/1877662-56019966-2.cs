c#
public class StateCityMaster
{
    public string CityName { get; set; }
    public long CityId { get; set; }
    public long StateId { get; set; }
    public string StateName { get; set; }
}
than edit the query as:
List<StateCityMaster> objStateCityMaster = dbContext.Database.SqlQuery<StateCityMaster>(
$@"select 
    CM.CityName,
    CM.CityId,
    SM.StateId,
    SM.StateName
from CityMaster CM
left join StateMaster SM
    On SM.StateId= CM.StateId").ToList();
then create the list of `CityMaster` objects and copy values:
List<CityMaster> citiesMaster = new List<CityMaster>();
objStateCityMaster.forEach(scm => citiesMaster.Add(new CityMaster()
{
    CityName = scm.CityName;
    CityId = scm.CityId;
    objStateMaster.StateId = scm.StateId;
    objStateMaster.StateName = scm.StateName;
}));
