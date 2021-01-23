    public class BaseController
    {
      private IScreenRepository _screen = NullScreenRepository.Instance;
      public IScreenRepository Screen {get { return _screen; } set { _screen = value; } } 
    
    }
