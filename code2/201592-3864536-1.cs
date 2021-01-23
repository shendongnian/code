    Interface IPolicy{
        int Reg {get;set;};
        string Contents {get;set;};
    }
    MotorPolicy : Policy,IPolicy {
     string IPolicy.Contents 
         {get;set;};
     int IPolicy.Reg 
         {get;set;};
    }
    
    HouseholdPolicy : Policy , IPolicy {
     string IPolicy.Contents 
         {get;set;};
     int IPolicy.Reg 
         {get;set;};
    }
