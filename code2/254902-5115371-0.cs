    public class ControlClass
    {
         public BusinessObject ActiveReport { get; set; }
         
    
         private UserInfo _editableUserData 
         public UserInfo EditableUserData
         {
             get { return _editableUserData; }
             set
             { 
                 if (_editableUserData != null)
                       _editableUserData.PropertyChanged -= UserDataChanged;
                 
                 _editableUserData = value;
                 
                 if (_editableUserData != null)
                      _editableUserData.PropertyChanged += UserDataChanged;
    
                 RaisePropertyChanged("EditableUserData");
             }
         }
    
         private void UserDataChanged(object sender, PropertyChangedEventArgs e)
         {
               if (ActiveReport == null)
                    ActiveReport = new BusinessObject(EditableUserData);
         }
    }
