     public partial class IBaseEvent
    {
        public Action MyAction;
        
        public void Execute()
        {
            MyAction();
        }
        public void AddFunction(Action ff)
        {
            MyAction += ff;
        }
    }
