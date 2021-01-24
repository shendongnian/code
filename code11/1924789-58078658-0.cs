public struct A 
{
    private int value;
    public A(int value) => this.value = value;
}
public void SomeMethod(int i, float f, string s = "", A a = default)
And then the input value will be `a : A{value = 0}`.
A general solution for using a class does not exist in C#, since default values are required to be determinable by compile time and must thus be constant expressions. Only valid constant expressions in C# are primitives, value types, and strings.
