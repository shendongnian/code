 c#
/// <summary>
/// description of foo in DerivedClass
/// </summary>
public int foo
{
    get { return base.foo; }
    set { base.foo = value = value; }
}
But you will need to re-declare the method. This could be via a `virtual` / `override` pair, or could be via a `new` (member-hiding) member.
