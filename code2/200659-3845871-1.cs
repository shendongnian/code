    public Class CDCost
    {
      public double Monthly {get;set;}
      public double Annually {get return Monthly*12;}  
      public CDCost(double monthly)
      {
        Monthly=monthly;
      }
    }
