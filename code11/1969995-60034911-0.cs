private ContactVm _selectedContact;
public ContactVm SelectedContact
{
   set
   {
      if (_selectedContact!= value)
      {
          _selectedContact= value;
                   
          SelectedContact.FirstName="Test";
          NotifyPropertyChanged("SelectedContact");
      }
   }
   get { return _selectedContact; }
}
And don't forget to implement the **INotifyPropertyChanged**  to your model .
