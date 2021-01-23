    [STAThread]
    static void Main()
    {   // just some example code to show it working in winforms, but
        // anything using System.ComponentModel should see the change
        Application.EnableVisualStyles();        
        Application.Run(new Form {Controls = {new PropertyGrid {Dock = DockStyle.Fill, SelectedObject = new Foo()}}});
    }
    class Foo
    {   // assume the following literals are keys, for example to a RESX
        [LocalizedCategory("cat")]
        [LocalizedDescription("desc")]
        [LocalizedDisplayName("disp name")]
        public string Bar { get; set; }
    }
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter)]
    class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        static string Localize(string key)
        {
            // TODO: lookup from resx, perhaps with cache etc
            return "Something for " + key;
        }
        public LocalizedDescriptionAttribute(string key)
            : base(Localize(key))
        {
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event)]
    class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        static string Localize(string key)
        {
            // TODO: lookup from resx, perhaps with cache etc
            return "Something for " + key;
        }
        public LocalizedDisplayNameAttribute(string key)
            : base(Localize(key))
        {
        }
    }
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter)]
    class LocalizedCategoryAttribute : CategoryAttribute
    {
        public LocalizedCategoryAttribute(string key) : base(key) { }
        protected override string  GetLocalizedString(string value)
        {
 	            // TODO: lookup from resx, perhaps with cache etc
            return "Something for " + value;
        }
    }
