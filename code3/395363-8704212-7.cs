public class ServiceSelectingWhatCallToMake : IHaveCookies
{
  public ServiceSelectingWhatCallToMake(IHaveCookies localCalls, IHaveCookies networkCalls)
  {
    // save in member variables
  }
  public SomeMethod()
  {
    if (somethingDescribingIShouldMakeLocalCall)
       this.localCalls.SomeMethod();
    else
       this.networkCalls.SomeMethod();
  }
}
