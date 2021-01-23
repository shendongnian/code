    public class MyPageStatePersister : System.Web.UI.HiddenFieldPageStatePersister
    {
         
         public MyPageStatePersister(Page page)
            : base(page)
        {
         }
        public override void Load()
        {
            base.Load();
            this.CurrentKey = (Guid)this.ViewState;
            var s = this.CurrentKey;
            var state = SomeDAOManager.GetState(s);
            if (state != null)
            {
                this.ViewState = state.First;
                this.ControlState = state.Second;
            }
            else
            {
                this.ControlState = null;
                this.ViewState = null;
            }
        }
        public Guid CurrentKey {get;set;}
        
        
        public override void Save()
        {
            if (CurrentKey == Guid.Empty)
            {
                this.CurrentKey = Guid.NewGuid();
            }
            Guid guid  = CurrentKey;
            SomeDAOManager.SaveState(guid, new Pair(this.ViewState, this.ControlState));
            this.ViewState = guid;
            this.ControlState = null;
            base.Save();
            
        }
    }
