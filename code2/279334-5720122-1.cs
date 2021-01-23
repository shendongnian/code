    public class Effect : INotifyPropertychanged
    {
        //Some properties
   
        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected;}
            set { isSelected=value;//plus raise propertychanged notification}
        }      
    }
