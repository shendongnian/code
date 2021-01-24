    public interface IMyInter
    {
        ReadOnlyObservableCollection<Data> files { get; }
    }
    public class Class1 : IMyInter
    {
        private readonly ObservableCollection<Data> _files = new ObservableCollection<Data>();
        public ReadOnlyObservableCollection<Data> files { get; } = new ReadOnlyObservableCollection<Data>(_files);
    
        void DoSomething()
        {
             _files.Add(new Data());
        }
    }
