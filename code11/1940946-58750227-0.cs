interface ICar
{
   int ID { get; set; }
   ICarInfo Info { get; set; }
}
your SUV has to look like this (at minimum):
class SUV : ICar
{
    public int ID { get; set; }
    public ICarInfo Info { get; set; }
}
of course you can add any other property or function to your SUV class.
I think what you expected was some kind of inheritance: As the SUVInfo already implements ICarInfo interface you can just declare an property of type SUVInfo. But Interface implementation in C# does not work like this.
