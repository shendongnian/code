    [Export(typeof(LeftViewModel))]
    public class LeftViewModel : PropertyChangedBase, IShell
    {
        [ImportingConstructor]
        public LeftViewModel(IEventAggregator events)
        {
            events.Subscribe(this);
            ...
        }
        ...
    }
