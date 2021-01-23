    public class FooClass
    {
       private string foo;
       public string Foo
       {
         get { return foo; }
         set
         {
           if(!string.IsNullOrEmpty(value) && value.Length>5)
           {
                foo=value.Substring(0,5);
           }
           else
                foo=value;
         }
       }
    }
