    private class Version1 {
      private readonly string[] underlyingData=new string[50];
      public string Foo1 { get { return ReadFoo(1); } set { SetFoo(1, value); } }
      public string Foo2 { get { return ReadFoo(2); } set { SetFoo(2, value); } }
      public string Foo3 { get { return ReadFoo(3); } set { SetFoo(3, value); } }
      //......
      public string Foo50 { get { return ReadFoo(50); } set { SetFoo(50, value); } }
      private string ReadFoo(int index) {
        return underlyingData[index-1]; //1-based indexing
      }
      private void SetFoo(int index, string value) {
        underlyingData[index-1]=value; //1-based indexing
      }
    }
