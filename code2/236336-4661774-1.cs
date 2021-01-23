    public class ViewModel
    {
        private readonly MainVM _parent;
        public MainVM Parent => _parent;
        public ViewModel(MainVM parent)
        {
              _parent = parent;
        }
     }
     
