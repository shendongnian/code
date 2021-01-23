    // Business Service
    public IList<Person> GetAllActivePeople()
    {
     var people = _yourDataRepository.FindActive();
     foreach(var p in people)
     {
      p.MyRelativeDateField = ConvertToRelativeHoursDays(p.MyDateField);
     }
     return people;
    }
    // probably better as a utility class if other dates of other objects can use this...
    private string ConvertToRelativeHoursDays(DateTime someDate)
    {
        // implement formatting here
    }
