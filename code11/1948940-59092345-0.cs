    public delegate void D();
    internal interface I 
    {
      D D { get; set; }
    }
    class P : I
    {
      public D D { get; set; }
      static void Main()
      {
        (new P()).M();
      }
      private void M()
      {
        C c1 = new C(this, "NAME1");
        C c2 = new C(this, "NAME2");
        c1.SetD();
        this.D();
        c2.SetD();
        this.D();
      }
    }
    class C
    {
      private I i;
      private string name;
      public C(I i, string name) 
      {
        this.name = name;
        this.i = i;
      }
      public void SetD()
      {
        this.i.D = () => { whatever };
      }
    }
