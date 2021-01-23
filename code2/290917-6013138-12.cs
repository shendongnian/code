    class HedgeHog_And_AfricanCountry
    {
    
       private HedgeHog _hedgeHog;
       private Nation _africanNation;
    
       public ulong NumberOfQuills { get { return _hedgeHog.NumberOfQuills; } }
       public int CountOfAntsEatenToday { get { return _hedgeHog.AntsEatenToday.Count(); } }
       public decimal GrossDomesticProduct { get { return _africanNation.GDP; } }
       public ulong Population { get { return _africanNation.Population; } }
    }
