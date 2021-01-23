    public YourPage() 
    {
        ...    
        ActualSurvey.Init += ActualSurvey_Init;
    }
    void ActualSurvey_Init(object sender, EventArgs e)
    {
          object banks = Cache["ActualSurvey_Banks"];
          if (banks == null)
          {
             banks = new BankManager().GetBanks();
             Cache.Insert("ActualSurvey_Banks", banks);
          }
          ActualSurvey.DataSource = banks;
          ActualSurvey.DataBind(); 
    }
