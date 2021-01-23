     interface IFoo: IDisposable { int Bar {get;set;}}
     struct Foo : IFoo
     {
       public int Bar { get; set; }
       public void Dispose() 
       {
         Console.WriteLine("Disposed: {0}", Bar);
       }
     }
