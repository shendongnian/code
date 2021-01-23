    private class Version2 {
      private static readonly Func<Version2, string>[] readers=new Func<Version2, string>[] {
        c => c.Foo1,
        c => c.Foo2,
        c => c.Foo3,
        //......
        c => c.Foo50,
      };
      private static readonly Action<Version2, string>[] writers=new Action<Version2, string>[] {
        (c,v) => c.Foo1=v,
        (c,v) => c.Foo2=v,
        (c,v) => c.Foo3=v,
        //......
        (c,v) => c.Foo50=v,
      };
      public string Foo1 { set; get; }
      public string Foo2 { set; get; }
      public string Foo3 { set; get; }
      //......
      public string Foo50 { set; get; }
      private string ReadFoo(int index) {
        return readers[index-1](this); //1-based indexing
      }
      private void SetFoo(int index, string value) {
        writers[index-1](this, value); //1-based indexing
      }
    }
