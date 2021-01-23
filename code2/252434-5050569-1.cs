    [Export(typeof(IView))]
    public class FooView
    {
        [ImportMany(IFooViewPlugin)]
        public IEnumerable<IFooViewPlugin> Plugins { get; set; }
        ...
    }
