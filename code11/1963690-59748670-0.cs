interface I1
{ 
    void M(int) { }
}
interface I2
{
    void M(short) { }
}
interface I3
{
    override void I1.M(int) { }
}
interface I4 : I3
{
    void M2()
    {
        base(I3).M(0) // What does this do?
    }
}
