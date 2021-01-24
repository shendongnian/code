    public class ViewModel1 {
        public ViewModel2 ChildVm {get;} = new ViewModel2();
    
        public ViewModel1() {
            ChildVm.Updated += OnChildUpdated;
        }
    
        private void OnChildUpdated(object pSender, EventArgs pArgs) {
            // do what is needed
        }
    }
    
    public class ViewModel2 {
        public event EventHandler Updated;
    
        public void DoStuff()
        {
            // do something
            if (Updated != null)
                Updated.Invoke(this, EventArgs.Empty);
        }
    }
