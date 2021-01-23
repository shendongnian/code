public class ServiceThatDoesntKnowWhatCallItMakes : IHaveCookies
{
  public ServiceSelectingWhatCallToMake(IHaveCookiesFactory factory)
  {
    // save in member variables
  }
  public SomeMethod()
  {
    var localOrNetwork = this.factory.Create(somethingDescribingWhatCallToMake)
    localCalOrNetwork.SomeMethod();
  }
}
