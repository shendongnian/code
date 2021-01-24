     private bool _isValid;
     public bool IsValid
     {
         get { return _IsValid; }
         set 
         {
             _isValid = value;
             NotifyPropertyChanged("IsValid");
             NotifyPropertyChanged("UserStatusColor");
         }
     }
     public Brush UserStatusColor
     {
         get { return IsValid ? Brushes.Green : Brushes.Red; }
     }
     
….
    <Rectangle Fill="{Binding UserStatusColor}"/>
