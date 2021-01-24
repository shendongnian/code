public class BaseClass
{
    protected abstract SomeType GetX(OtherType r);
    … SomeType x = GetX(r);
}
public class A
{
    protected override SomeType GetX(OtherType r) => r?.abc?.FirstOrDefault();
}
Which member of r each classes accesses is class-specific behavior, and should go in each class.
