    public interface IView
    {
        /// <summary>Update the view</summary>
        void UpdateView(object myBusinessObject);
    
        /// <summary>Display message</summary>
        void ShowMessage(string msg);
    }
    
    public class BL
    {
        // Model and View
        private IView _view;
    
        /// <summary>Constructor</summary>
        public BL (IView view)
        {
            _view = view;
        }
        
        public void foo()
        {
            // Do something
            
            // Show message
            _view.ShowMessage("Hello World");
        }
    }
