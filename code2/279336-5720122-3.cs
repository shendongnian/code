    public class Effect : INotifyPropertychanged
    {
        //Some properties
   
        private bool isVisible;
        public bool IsVisible
        {
            get { return isVisible;}
            set { isVisible=value;//plus raise propertychanged notification}
        }      
    }
