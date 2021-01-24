    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using WpfApp1.ViewModels;
    namespace WpfApp1
    {
        public class MainViewModel : ViewModelBase<MainModel>
        {
            private DeviceViewModel selectedDevice;
            public ObservableCollection<DeviceViewModel> DeviceList
            {
                get { return Model.DeviceList; }
            }
            public DeviceViewModel SelectedDevice
            {
                get { return selectedDevice; }
                set
                {
                    selectedDevice = value;
                    RaisePropertyChanged("SelectedDevice");
                }
            }
            public MainViewModel() : base(new MainModel())
            {
            }
            public void AddDevice()
            {
                int rnd = new Random().Next(1, 100);
                if (!Model.DeviceList.Any(x => x.Name == $"Device_{rnd}"))
                    Model.DeviceList.Add(new DeviceViewModel($"Device_{rnd}"));
                RaisePropertyChanged("DeviceList");
            }
        }
    }
    using System.Collections.ObjectModel;
    using WpfApp1.ViewModels;
    namespace WpfApp1
    {
        public class MainModel
        {
            private ObservableCollection<DeviceViewModel> deviceList;
            public ObservableCollection<DeviceViewModel> DeviceList
            {
                get { return deviceList; }
                set { deviceList = value; }
            }
            public MainModel()
            {
                deviceList = new ObservableCollection<DeviceViewModel>();
            }
        }
    }
