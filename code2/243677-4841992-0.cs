    public class EntityFilterViewModel()
    {
        string PowerPlanet {get;set;}
        string GeneratingUnits {get;set;}
        string Period{get;set;} // Simplification, you should use timespan or something.
        DateTime BeginTime {get;set;}
        DateTime EndTime {get;set;}
    }
