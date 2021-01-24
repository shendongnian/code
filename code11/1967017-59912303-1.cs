    using Caliburn.Micro;
    using ConfigUI.Library.Models;
    using ConfigUI.Local;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConfigUI.ViewModels
    {
        public class ShowDevicesViewModel: Screen
        {
            private BindableCollection<DetecctedDevice> _devices;
    
            public BindableCollection<DetecctedDevice> Devices
            {
                get { return _devices; }
                set {
                    _devices = value;
                    NotifyOfPropertyChange(() => Devices);
                }
            }
    
            public ShowDevicesViewModel()
            {
                _devices = new BindableCollection<DetecctedDevice>(LocalDevices.GetLocalDevices());
            }
    
            public void ImageClicked(DetecctedDevice selectedDevice)
            {
                Console.WriteLine();
            }
        }
    }
