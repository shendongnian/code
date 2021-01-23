    public class VMMgr : IViewModelManager
    {
        private ObservableCollection _oc;
        public ObservableCollection Collection { get { return _oc; } }
        // other implementation
        public void DoNaughtyThings()
        {
            _oc = new ObservableCollection();
        }
    }
