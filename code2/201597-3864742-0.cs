    public abstract class Response
    {
      public abstract Policy Policy {get;}//can be used for stuff for dealing with all policies.
      public static Response GetResponse(Policy policy)
      {//factory method
        if(policy is MotorPolicy)
          return new MotorResponse((MotorPolicy)policy);
        if(policy is HouseholdPolicy)
          return new HouseholdResponse((HouseholdPolicy)policy);
        throw new ArgumentException("Unexpected policy type");
      }
    }
    public class MotorResponse : Response
    {
      private readonly MotorPolicy _motorPolicy;
      public MotorResponse(MotorPolicy policy)
      {
        _motorPolicy = policy;
      }
      protected override Policy Policy
      {
        get { return _motorPolicy; }
      }
      // motor specific stuff
    }
    public class HouseholdResponse : Response
    {
      private readonly HouseholdPolicy _householdPolicy;
      public HouseholdResponse(HouseholdPolicy policy)
      {
        _householdPolicy = policy;
      }
      protected override Policy Policy
      {
        get { return _householdPolicy; }
      }
      // household specific stuff
    }
