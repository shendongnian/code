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
    
    public MyDerivedClass : base()
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
