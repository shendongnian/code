    [Export(typeof(IShell))]
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        [ImportingConstructor]
        public ShellViewModel(LeftViewModel leftModel)
        {
            ...
        }
        ...
    }
