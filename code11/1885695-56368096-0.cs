    public class OrganizationServiceProxy : IServiceProxy
      {
        public int SomeProp
        {
          get
          {
            return 1;
          }
    
          set
          {
          }
        }
    
        public TimeSpan Timeout
        {
          get
          {
            return new TimeSpan();
          }
    
          set
          {
          }
        }
    
        public void SomeMethod()
        {
        }
      }
      public interface IServiceProxy : IOrganizationService
      {
        TimeSpan Timeout { get; set; }
      }
    
      public interface IOrganizationService
      {
        void SomeMethod();
        int SomeProp { get; set; }
      }
