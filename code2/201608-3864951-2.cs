    public abstract class Policy
    { 
        protected virtual string GetDescription()
        {
             return string.Empty()    
        }
        
        public string Description 
        { 
            get 
            {
               return GetDescription();
            } 
        }
    }
    
    public MotorPolicy : Policy
    {
        public override string GetDescription()
        {
           return ..... ////specific description implementation for MotorPolicy
        }
    }
    
    public HouseHoldPolicy : Policy
    {
        public override string GetDescription()
        {
           return ..... ////specific description implementation for HouseholdPolicy
        }
    }
    
    
    public class Response        
    {        
        ...        
        private MotorPolicy                 _motorPolicy;        
        private HouseholdPolicy             _householdPolicy; 
        private PolicyType                  _policyType;       
        ....        
    
        public Policy Policy
        {
            get
            {
               if (_policyType== PolicyType.Motor) 
               {
                  return _motorPolicy;
               } 
               if (_policyType== PolicyType.Household) 
               {
                  return _householdPolicy;
               } 
    
               return null;
            }
        }        
    }    
