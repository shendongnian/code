    class ScreenShaker
    {
      public static ScreenShaker Instance {private set; get;};
    
      void Awake() {
      	Instance = this;
      }
    }
