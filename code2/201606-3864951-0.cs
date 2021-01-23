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
        privata _policyType PolicyType;       
        ....        
    
        public Policy Policy
        {
            get
            {
               if (policyType == PolicyType.Motor) 
               {
                  return _motorPolicy;
               } 
               if (policyType == PolicyType.Household) 
               {
                  return _householdPolicy;
               } 
    
               return null;
            }
        }        
    }    
