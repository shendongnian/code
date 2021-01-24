    [Serializable]
    public class BuildingViewModel
    {
       public string Name { get; set; }
       public BuildingCountryViewModel Country { get; set; }
    }
    
    [Serializable]
    public class BuildingCountryViewModel
    {
       public string Text { get; set; }
       public int Value { get; set; }
       public BuildingStateViewModel State { get; set; }
    }
    
    [Serializable]
    public class BuildingStateViewModel
    {
       public string Text { get; set; }
       public int Value { get; set; }
       public BuildingCityViewModel City { get; set; }
    }
    
    [Serializable]
    public class BuildingCityViewModel
    {
       public string Text { get; set; }
    }
