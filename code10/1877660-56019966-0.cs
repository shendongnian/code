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
then create the `CityMaster` object as:
CityMaster cityMaster = new CityMaster();
cityMaster.CityName = objStateCityMaster.CityName;
cityMaster.CityId = objStateCityMaster.CityId;
cityMaster.objStateMaster.StateId = objStateCityMaster.StateId;
cityMaster.objStateMaster.StateName = objStateCityMaster.StateName;
