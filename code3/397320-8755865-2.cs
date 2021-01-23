    public abstract class WorkspaceViewModel : BaseViewModel
    {
        public String HeaderText { get; set; }
        public override string ToString()
        {
            
               return HeaderText;
            
        }
    }
