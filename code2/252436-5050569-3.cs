    [Export(typeof(IView))]
    public class FooView : IView
    {
        [ImportMany(IFooViewPlugin)]
        public IEnumerable<IFooViewPlugin> Plugins { get; set; }
        ...
    }
