    //---- analyzer class ----
    private static List<string> MissingItemsInMapping = new List<string>();
    
    public IList<string> MissingItemsInMappingsList => MissingItemsInMapping;
    private readonly IPeopleService _peopleService;
    
    //constructor
    public Analyzer(IPeopleService peopleService)
    
    {
       _peopleService = peopleService;
    }
    
    //calling people service method
    var people = _peopleService.GetPeopleForEvent(category, date, MissingItemsInMapping);
    
    //---- People class ----
    public IList<People> GetPeopleForEvent(string category, DateTime date, List<string> information)
    {
      var ppl = new List<People>();
      If()
      {
        //some logic
    
        return ppl;
      }
      else
      {
        // You have access to MissingItemsInMapping here, use .Add, or whatever suits you
        // to add/modify the list.
        return information;
      }
    }
