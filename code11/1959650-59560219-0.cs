public class Mammal
{
  public int LegCount { get; set; }
}
public class Human  : Mammal
{
  public List<string> SpokenLanguages { get; set; }
}
public class Squirrel : Mammal
{
  public bool CanFly { get; set; }
}
public void PrintNumberOfLegs(Mammal mammal)
{
  // do something with mammal.LegCount
}
``
This `PrintNumberOfLegs` supports all of those classes, but doesn't directly have access to the derived type properties (SpokenLanguages or CanFly) and it doesn't need them to do it's job.  In this case we now have a single method that supports any number of Mammals and even future mammals.  If another programmer cam a long and did:
public class Whale : Mammal
{
  // whatever for a whale
}
Our method still works.
