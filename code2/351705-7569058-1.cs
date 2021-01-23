    public class PropertyBinding
    {
        public static PropertyBinding To(ViewModel vm, Name name, string label)
        {
            return new PropertyBinding { ViewModel = vm, Getter = new Func<string>(delegate() { return name.Value; }), Setter = new Action<string>(delegate(string value) { name.Value = value; }), Label = label };
        }
        public string Label { get; set; }
        public ViewModel ViewModel { get; set; }
    
        public Func<string> Getter { get; set; }
        public Action<string> Setter { get; set; }
        public string Value
        {
            get { return this.Get(); }
            set { this.Set(value); }
        }
        internal string Get()
        {
            // Implement UpdatePersonNamePropert here.
            // Maybe convert culture before returning.
            return this.Getter();
        }
        internal void Set(string value)
        {
            // Maybe convert culture before storing.
            this.Setter(value);
        }
    }
