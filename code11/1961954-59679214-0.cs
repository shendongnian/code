interface I1
{
    void Foo(bool x = false);
}
interface I2
{
    void Foo(bool x = true);
}
class C : I1, I2
{
   ...?
}
If you did want to specify a default value for `C.Foo`, this case could be solved by explicitly implementing one of the interfaces:
class C : I1, I2
{
    public void Foo(bool x = false) { ... }
    void I2.Foo(bool x) => Foo(x);
}
Alternatively you could just ignore this case, and not warn.
### Adding an interface in a child class
interface I1
{
    void Foo(bool x = false);
}
class Parent
{
    public void Foo(bool x = true) { ... }
}
class Child : Parent, I1
{
    ...?
}
I'm not sure what an intuitive solution to this would be, but since it's so niche I'd be tempted just to ignore it, and not warn.
