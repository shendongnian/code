c#
class Dog : IThingWithId 
{
    // the desired members in your class
    public int DogId { get; set; }
    public Dog() 
    {
    }
    // the wrapper member required by the interface
    int IThingWithId.Id => DogId;
}
