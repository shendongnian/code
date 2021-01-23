    public class Foo
    {
        private string _string1;
        public Foo foo { get; set; }
    
        private T GetProperty<T>(Func<Foo,T> getter)
        {
            return foo == null
                       ? getter(this)
                       : getter(foo);
        }
    
        private void SetProperty(Action<Foo> setter)
        {
            if (foo == null)
                setter(this);
            else
                setter(foo);
        }
    
        public string String1
        {
            get { return GetProperty(a => a._string1); }
            set { SetProperty(a => a._string1 = value); }
        }
    }
