    public class MyCoolControl : Control
    {
        private Form _customForm;
    
        public MyCoonControl()
        {
           _customForm.Clicked += (source, e) => Clicked(source,e);
        }
    
        public event EventHandler Clicked = delegate {};
    }
