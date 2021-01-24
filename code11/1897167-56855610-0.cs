    public class PersonDto
      {
        private Status status;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
    
        public Status LivingStatus
        {
          get => status;
    
          set
          {
            status = value;
    
            switch (status)
            {
              case Status.Homeowner:
                IsHomeOwner = true;
                IsTenant = false;
                IsLivingWithParents = false;
                break;
    
              case Status.LivingWithParents:
                IsHomeOwner = false;
                IsTenant = false;
                IsLivingWithParents = true;
                break;
    
              case Status.Tenant:
                IsHomeOwner = false;
                IsTenant = true;
                IsLivingWithParents = false;
                break;
    
              default:
                throw new ArgumentOutOfRangeException();
            }
          }
        }
    
    
        public bool IsHomeOwner { get; set; }
        public bool IsTenant { get; set; }
        public bool IsLivingWithParents { get; set; }
      }
