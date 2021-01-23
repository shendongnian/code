    class auto_disposer<C> : IDisposable where C : class
    {
        public C Child { get; private set; }
        public auto_disposer(C c) { Child = c; }
   
        public void Dispose() { IDisposable d =  Child as IDisposable; if (d != null) d.Dispose(); }
        public C Release() { C retval = Child; Child = null; return retval; }
    }
    class Foo
    {
         static public Form FormAsControl()
         {
             using (var ad = new auto_disposer<Foo>(new Foo())) {
                 Form form = ad.Child;
                 form.TopLevel = false;
                 form.FormBorderStyle = FormBorderStyle.None;
                 form.Dock = DockStyle.Fill;
                 form.Visible = true;
                 return ad.Release();
             }
         }
         // ...
    }
