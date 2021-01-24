public class MyBaseClass
{
    public MyBaseClass ()
    {
        Console.WriteLine (this.ToString());
    }
}
public class MyDerivedClass : MyBaseClass
{
    string name="hello";
    
    public MyDerivedClass() : base()
    {
        Console.WriteLine (this.ToString());
    }
    public override string ToString()
    {
        return name;
    }
}
> When a new instance of MyDerivedClass is created in C#, the output is:
>     hello
>     hello
> The first line is hello because the instance variable initializer for the name variable has run directly before the base class constructor. The equivalent code in Java syntax would output:
>     null
>     hello 
I wouldn't consider this example to be particularly contrived: it's not unthinkable that someone would call a virtual method (like `ToString()`) in a base class, nor that a virtual method would try to use a member variable. In fact, it wouldn't be very far-fetched to assume that this is something Jon might have run into personally, considering he has authored libraries and their ports in both languages.
But, as he mentions:
> This is a really bad idea - wherever possible, only call non-virtual methods from constructors, and if you absolutely must call a virtual method, document very carefully that it is called from the constructor, so that people wishing to override it are aware that their object may not be in a consistent state when it is called (as their own constructor won't have run yet). 
So anti-pattern: yes. Deliberately designed? Perhaps not.
