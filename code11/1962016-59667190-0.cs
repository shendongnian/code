public class Parent
{
    public void Run() => Console.WriteLine("Parent");
}
public class Child : Parent
{
    public new void Run() => Console.WriteLine("Child");
}
var child = new Child();
child.Run(); // prints "Child"
((Parent)child).Run(); // prints "Parent"
Shadowing is rarely a good idea as it can be confusing when an object changes its behaviour depending on the type of its variable. For more on shadowing, have a look at e. g. [this question](https://stackoverflow.com/q/673779/1344058).
