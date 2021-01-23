     using System;
     using System.ComponentModel;
     using System.Threading;
     using System.Diagnostics;
     using GalaSoft.MvvmLight;
     using GalaSoft.MvvmLight.Messaging;
    namespace MvvmLightCheck.Model
    {
        // This is the Model class for our 'active boolean'
        // It implements all logic for actively changing the value of our 
        // boolean.  It does this on a background thread.
        //
        // Model classes implement INotifyPropertyChanged which enables binding clients
        // to be notified when a property changes.
        // 
        // This is pure .NET/Silverlight and is not specific to Mvvm
        //
        public class OnOffSwitchClass : ViewModelBase
        {
            private const Int32 TIMER_INTERVAL = 5000;  // 5 seconds
            private Timer _timer;
            // Upon creation create a timer that changes the value every 5 seconds
            public OnOffSwitchClass()
            {
                _timer = new System.Threading.Timer(TimerCB, this, TIMER_INTERVAL, TIMER_INTERVAL);
            }
            private static void TimerCB(object state)
            {
                // Alternate between on and off
                ((OnOffSwitchClass)state).PowerState = !((OnOffSwitchClass)state).PowerState;
            }
            /// <summary>
            /// The <see cref="PowerState" /> property's name.
            /// </summary>
            public const string PowerStatePropertyName = "PowerState";
            private bool _myProperty = false;
            /// <summary>
            /// Gets the PowerState property.
            /// TODO Update documentation:
            /// Changes to that property's value raise the PropertyChanged event. 
            /// This property's value is broadcasted by the Messenger's default instance when it changes.
            /// </summary>
            public bool PowerState
            {
                get
                {
                    return _myProperty;
                }
                set
                {
                    if (_myProperty == value)
                    {
                        return;
                    }
                    var oldValue = _myProperty;
                    _myProperty = value;
                    // Update bindings and broadcast change using GalaSoft.MvvmLight.Messenging
                    GalaSoft.MvvmLight.Threading.DispatcherHelper.CheckBeginInvokeOnUI(() => 
                        RaisePropertyChanged(PowerStatePropertyName, oldValue, value, true));
                }
            }
        }
 
    }
