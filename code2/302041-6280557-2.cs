    interface IChangeableSkin : ISkin
    {
        event EventHandler SkinChanged;
    }
    public class SkinProxy : IChangeableSkin 
    {
        private ISkin _skin; // actual underlying skin
     
        public void SetSkin(ISkin newSkin)
        {
            if (newSkin == null)
               throw new ArgumentNullException("newSkin");
        
            if (newSkin == _skin)
               return; // nothing changed
        
            // detach handlers from previous instance
            DetachHandlers();
            
            // swap the instance
            _skin = newSkin;
            
            // attach handlers to the new instance
            AttachHandlers();
            
            // fire the skin changed event
            SkinChanged(this, EventArgs.Empty);
        }
        
        void DetachHandlers()
        {
            if (_skin != null)
               _skin.BlinkEvent -= OnBlink;
        }
        
        void AttachHandlers()
        {
            if (_skin != null)
               _skin.BlinkEvent += OnBlink;
        }
        
        void OnBlink(object sender, EventArgs e)
        {
            // just forward the event
            BlinkEvent(this, e);
        }
        
        // constructor
        public SkinProxy(ISkin initialSkin)
        {
            SetSkin(initialSkin);
        }
    
        #region ISkin members
        
        public void RenderButton(IContext ctx)
        {
            // just calls the underlying implementation
            _skin.RenderButton(ctx);
        }
        
        // this is fired inside OnBlink
        public event EventHandler BlinkEvent = delegate { }; 
        
        #endregion
        #region IChangeableSkin members
        public event EventHandler SkinChanged = delegate { }; 
  
        #region
    }
