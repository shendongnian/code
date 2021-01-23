    public BaseMasterPage : MasterPage
    {
      protected string UserSession
      {
        get
        {
          return (Page as BasePage).UserSession;
        }
        set
        {
          (Page as BasePage).UserSession = value;
        }
      }
    }
