    // inside ThisAddIn class
    public static ThisAddIn Active {
      get;
      private set;
    }
    // inside ThisAddIn_Startup
    Active = this;
    // later on, after add-in initialization, say in Ribbon1.button1_Click
    ThisAddIn.Active.displayCount();
