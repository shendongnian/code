    public class FillQualityAssessment:IUserRights{
      private readonly Application _application;
      public FillQualityAssessment(Application application){
        Guard.AgainstNull(application,
          "User rights check failed. Application not specified.");
        _application=application;
      }
      public bool IsSatisfiedBy(User u){
        return u.IsInRole(Role.Assessor)&&_application.Assessors.Contains(u);
      }
      public void CheckRightsFor(User u){
        if(!IsSatisfiedBy(u))
          throw new ApplicationException
            ("User is not authorized to fill quality assessment.");
        }
      }
