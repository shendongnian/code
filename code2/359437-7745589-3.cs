    public class ComboButton : WebControl, IPostBackDataHandler  
    {
        public virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            return true;
        }
        public virtual void RaisePostDataChangedEvent()
        {
            
        }
    }
