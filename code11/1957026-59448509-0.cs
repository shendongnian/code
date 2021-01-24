interface IFoo { }
class Bar : IFoo
{
    public string Prop { get; set; }
}
void Method()
{
    IFoo foo = new Bar();
    foo.Prop; // Here, you will see error from VS, but still can see/update it in Locals
}
So, in your case, just check a type of you variable in Locals window (third column) and actual type in code, probably, they are different.
