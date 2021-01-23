    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    namespace MyCompany.MyProject.ViewModel
    {
        public class EntryViewModel : INotifyPropertyChanged
        {
            private readonly string _initialName;
            private readonly string _initialEmail;
            private readonly string _initialPhoneNumber;
            private readonly string _initialRelationship;
            private string _name;
            private string _email;
            private string _phoneNumber;
            private string _relationship;
            private bool _isInEditMode;
            private readonly DelegateCommand _makeEditableOrRevertCommand;
            private readonly DelegateCommand _saveCommand;
            private readonly DelegateCommand _cancelCommand;
            public EntryViewModel(string initialNamename, string email,
                string phoneNumber, string relationship)
            {
                _isInEditMode = false;
                _name = _initialName = initialNamename;
                _email = _initialEmail = email;
                _phoneNumber = _initialPhoneNumber = phoneNumber;
                _relationship = _initialRelationship = relationship;
                MakeEditableOrRevertCommand = _makeEditableOrRevertCommand =
                    new DelegateCommand(MakeEditableOrRevert, CanEditOrRevert);
                SaveCommand = _saveCommand =
                    new DelegateCommand(Save, CanSave);
                CancelCommand = _cancelCommand =
                    new DelegateCommand(Cancel, CanCancel);
            }
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
            public string Email
            {
                get { return _email; }
                set
                {
                    _email = value;
                    RaisePropertyChanged("Email");
                }
            }
            public string PhoneNumber
            {
                get { return _phoneNumber; }
                set
                {
                    _phoneNumber = value;
                    RaisePropertyChanged("PhoneNumber");
                }
            }
            public string Relationship
            {
                get { return _relationship; }
                set
                {
                    _relationship = value;
                    RaisePropertyChanged("Relationship");
                }
            }
            public bool IsInEditMode
            {
                get { return _isInEditMode; }
                private set
                {
                    _isInEditMode = value;
                    RaisePropertyChanged("IsInEditMode");
                    RaisePropertyChanged("CurrentEditModeName");
                    _makeEditableOrRevertCommand.RaiseCanExecuteChanged();
                    _saveCommand.RaiseCanExecuteChanged();
                    _cancelCommand.RaiseCanExecuteChanged();
                }
            }
            public string CurrentEditModeName
            {
                get { return IsInEditMode ? "Revert" : "Edit"; }
            }
            public ICommand MakeEditableOrRevertCommand { get; private set; }
            public ICommand SaveCommand { get; private set; }
            public ICommand CancelCommand { get; private set; }
            private void MakeEditableOrRevert()
            {
                if (IsInEditMode)
                {
                    // Revert
                    Name = _initialName;
                    Email = _initialEmail;
                    PhoneNumber = _initialPhoneNumber;
                    Relationship = _initialRelationship;
                }
                IsInEditMode = !IsInEditMode; // Toggle the setting
            }
            private bool CanEditOrRevert()
            {
                return true;
            }
            private void Save()
            {
                AssertEditMode(isInEditMode: true);
                IsInEditMode = false;
                // Todo: Save to file here, and trigger close...
            }
            private bool CanSave()
            {
                return IsInEditMode;
            }
            private void Cancel()
            {
                AssertEditMode(isInEditMode: true);
                IsInEditMode = false;
                // Todo: Trigger close form...
            }
            private bool CanCancel()
            {
                return IsInEditMode;
            }
            private void AssertEditMode(bool isInEditMode)
            {
                if (isInEditMode != IsInEditMode)
                    throw new InvalidOperationException();
            }
            #region INotifyPropertyChanged Members
            public event PropertyChangedEventHandler PropertyChanged;
            private void RaisePropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this,
                        new PropertyChangedEventArgs(propertyName));
            }
            #endregion INotifyPropertyChanged Members
        }
    }
