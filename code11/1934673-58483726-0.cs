public string GetRace()
{
     string filter = "example";
     RaceJson currentRace = await gsaClient.SendCustomRequest<RaceJson>("races?$filter=" + filter);
}
public string GetPeople()
{
     string filter = "example";
     List<PeopleJson> currentPeople = await gsaClient.SendCustomRequest<List<PeopleJson>>("people?$filter=" + filter);
}
