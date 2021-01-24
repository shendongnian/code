    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using System.Windows.Threading;    
    namespace ViewModels
    {
        public class BaseViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public BaseViewModel()
            {
                 //ctor
            }
            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                UIThread( () =>
                {
                    //make sure the event is raised on the main thread
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                });
            }
            Dispatcher _dispacther;
            protected void UIThread(Action action)
            {
                if (_dispacther == null)
                {
                    _dispacther = Dispatcher.CurrentDispatcher;
                }
                _dispacther.Invoke(action);
            }
        }
    }  
