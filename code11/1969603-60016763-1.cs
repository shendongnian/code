class ThingClass : IThing
{
    public string GetThing()
    {
        throw new System.NotImplementedException();
    }
}
The second one 'Delegate implementation of 'IThing' to new field' yields the code in your original question: 
class ThingClass : IThing
{
    private IThing thingImplementation;
    public string GetThing()
    {
        return thingImplementation.GetThing();
    }
}
The second version is useful when you want to change implementations "on-the-fly". Maybe depending on a constructor parameter, or whatever your use case is.
  [1]: https://i.stack.imgur.com/GvNPT.png
