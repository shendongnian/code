 c#
abstract class AlmostA : BaseA
{
    public override int? Value => GetValue();
    protected int GetValue() => 4;
}
class A : AlmostA, IAbc
{
    public new int Value => GetValue();
}
---
If you only mean *for the purposes of satisfying the `IAbc` interface*, then "explicit interface implementation" is your friend:
 c#
class A : BaseA, IAbc
{
    private int GetValue() => 4;
    public override int? Value => GetValue();
    int IAbc.Value => GetValue();
}
