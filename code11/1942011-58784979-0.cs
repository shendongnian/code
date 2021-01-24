class Animal {}
class Turtle : Animal { public Color ShellColor {get;set;} }
abstract class AnimalCollection<T> 
{
   public IEnumerable<T> Animals {get; set;} 
}
class TurtleCollection : AnimalCollection<Turtle> {}
(...)
foreach( var t in new TurtleCollection().Animals)
{
    Console.WriteLine(t.ShellColor);
}
----
*(Update)*
Oh, yeah, https://stackoverflow.com/questions/21692193/why-not-inherit-from-listt is always a good read as well.
