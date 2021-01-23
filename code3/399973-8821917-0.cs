    public class Params
    {
      private object _lock = new object();
      private IEnumerable<Localization> _localizations;    
      public IEnumerable<Localization> Localizations
      {
        get
        {
          lock (_lock) {
             if ( _localizations == null ) {
                _localizations = new Repository<Localization>().Get();
             }
             return _localizations;
          }
        }
      }
        
      public void RebuildLocalizations()
      {
         lock(_lock) {
            _localizations = null;
         }
      }
    
      // other similar values coming from the DB and staying in-memory,
      // and their refresh methods
    
    }
