 c#
class Base
{
    public virtual object P1 { get; set; }
    public virtual object P2 { get; set; }
    public virtual object P3 { get; set; }
}
class Derived : Base
{
    public sealed override object P1 { set => base.P1 = value; }
    public override object P2 { set => base.P2 = value; }
}
I.e. the base class declares three virtual properties, all identical except for the name. Then the derived class overrides two of those virtual properties, sealing one of them.
If you take a look at the differences between the descriptor objects returned by reflection for the properties in `Derived`, you'll notice some things:
* Even though we haven't declared a getter for `P1`, reflection returns one anyway, with the `DeclaringType` property returning the `Derived` type.
* But for `P2`, reflection does _not_ return a getter (this relates to [your earlier question][1]).
* For `P3`, a getter is returned again, but for this one, the `DeclaringType` returns the `Base` type.
* For the `P1` getter, the `MethodBase.Attributes` includes `MethodAttributes.Final`, indicating that the method is sealed. This is the attribute that the compiler can't put on the base type (for obvious reasons), and so had to implement the method in the derived type, so that the attribute would have some place to live.
Finally, if we look at the generated code, we find that indeed, not only has the compiler created this method for us, it does in fact just delegate directly to the base class getter:
msil
.method public hidebysig specialname virtual final 
        instance object  get_P1() cil managed
{
  // Code size       7 (0x7)
  .maxstack  8
  IL_0000:  ldarg.0
  IL_0001:  call       instance object TestSO57762322VirtualProperty.Base::get_P1()
  IL_0006:  ret
} // end of method Derived::get_P1
  [1]: https://stackoverflow.com/q/57762322
