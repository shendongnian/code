    class HedgeHog_And_AfricanCountry
    {
    
       private HedgeHog _hedgeHog;
       private Nation _africanNation;
    
       public NumberOfQuills { get { return _hedgeHog.NumberOfQuills; } }
       public GrossDomesticProduct { get { return _africanNation.GDP; } }
       public Population { get { return _africanNation.Population; } }
       public CountOfAntsEatenToday { get { return _hedgeHog.AntsEatenToday.Count(); } }
    
    
    }
