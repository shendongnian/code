struct Outer
{
   public Inner inner;
   public Outer(int data) { this.inner = new Inner(data); }
   public Clone() { return new Outer(this.inner.data); }
}
