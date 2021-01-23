    public class ComboButton : WebControl, IPostBackEventHandler  
    {
        public void RaisePostBackEvent(string eventArgument)
        {
            OnSubmit(EventArgs.Empty); 
        }
    }
