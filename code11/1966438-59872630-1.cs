class Foo
{
    [Obsolete( "Do not use this field directly. Use the " + nameof(Foo.PositionB) + " property instead." )]
    private Vector3 position3;
    public Vector3 PositionB
    {
        get
        {
            #pragma warning disable 618 // Obsolete
            if( this.nodeB == null ) return this.positionB;
            else return this.nodeB.Position;
            #pragma warning restore 618
        }
        set
        {
            #pragma warning disable 618 // Obsolete
            this.positionB = value;
            this.UpdateMesh();
            #pragma warning restore 618
        }
    }
}
So this code will cause a compiler warning:
class Foo
{
    // [...]
    public void Bar()
    {
        this.positionB = 123; // this statement will cause a compiler warning
    }
}
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/cs0618
