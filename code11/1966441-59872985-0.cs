class Foo
{
    private struct Vector3Wrapper
    {
        private readonly Foo foo;
        private Vector3 value;
        public Vector3Wrapper( Foo foo )
        {
            this.foo   = foo;
            this.value = default;
        }
        public Vector3 GetValue()
        {
            //return this.foo.nodeB == null ? this.value : this.foo.nodeB.Position;
            return this.foo.nodeB?.Position ?? this.value; // <-- more succinct!
        }
        public void SetValue( Vector3 value )
        {
            this.value = value;
        }
    }
    private readonly Vector3Wrapper positionB;
    public Foo()
    {
        this.positionB = new Vector3Wrapper( this );
    }
    public Vector3 PositionB
    {
        get => this.positionB.GetValue();
        set
        {
            this.positionB.SetValue( value );
            this.UpdateMesh();
        }
    }
}
So this code will cause a compile-time error:
class Foo
{
    // [...]
    void Baz()
    {
        this.positionb = default; // will error because `this.positionB` is readonly (but not immutable)
    }
}
  [1]: https://en.wikipedia.org/wiki/Locality_of_reference
