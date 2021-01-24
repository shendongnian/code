    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    namespace SOF
    {
        public class SecurityViewModel : ObservableModel, INotifyPropertyChanged
        {
            public SecurityViewModel()
            {
                AddUserCommand = new RelayCommand(a => AddUserRequest(null),null);
            }
            public string AddUsername { get; set; }
            public ICommand AddUserCommand { get; set; }
            private string _addTempPassword;
            public string AddTempPassword
            {
                get { return _addTempPassword; }
                set
                {
                    _addTempPassword = value;
                    OnPropertyChanged(nameof(AddTempPassword));
                }
            }
            private void AddUserRequest(object parameter)
            {
                string test;
                test = AddTempPassword;
                //try
                //{
              //      **bool flag = Framework.SecurityManager.AddUser(AddUsername,
              //                    *AddTempPassword *, profileName); **
         
              //if (!flag)
              //      {
              //          MessageBox.Show(@"User was not able to be added.  Note: 
              //                   Usernames must be unique.");
              //      }
              //      else
              //      {
              //          MessageBox.Show(@"The user " + AddUsername + @" was 
              //                   added.");
              //      }
              //  }
              //  catch (Exception ex)
              //  {
              //      Logbook.WriteLog(Logbook.EventLevel.Error, ex);
              //  }
            }
        }
    }
