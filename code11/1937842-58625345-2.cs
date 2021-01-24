    using System.Collections.ObjectModel;
    using WpfApp1.Models;
    namespace WpfApp1.ViewModels
    {
        public class DeviceViewModel : ViewModelBase<Device>
        {
            private Fault selectedFault = null;
            public string Name
            {
                get { return Model.Name; }
                set
                {
                    Model.Name = value;
                    RaisePropertyChanged("Name");
                }
            }
            public string SerialNumber
            {
                get { return Model.Id.ToString(); }
            }
            public ObservableCollection<FaultViewModel> FaultList
            {
                get { return Model.FaultList; }
            }
            public Fault SelectedFault
            {
                get { return selectedFault; }
                set
                {
                    selectedFault = value;
                    RaisePropertyChanged("SelectedFault");
                }
            }
            public DeviceViewModel() : base(new Device())
            {
                FaultList.CollectionChanged += FaultList_CollectionChanged;
            }
            public DeviceViewModel(string name) : this()
            {
                Name = name;
                for (int i = 0; i < 5; i++)
                    Model.FaultList.Add(new FaultViewModel() { Name = $"Fault_{i} of {name}" });
                RaisePropertyChanged("FaultList");
            }
            private void FaultList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                RaisePropertyChanged("FaultList");
            }
        }
    }
    using System;
    using System.Collections.ObjectModel;
    namespace WpfApp1.Models
    {
        public class Device
        {
            private string name = "";
            private Guid id;
            private ObservableCollection<FaultViewModel> faultList;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public Guid Id
            {
                get { return id; }
                set { id = value; }
            }
            public ObservableCollection<FaultViewModel> FaultList
            {
                get { return faultList; }
                set { faultList = value; }
            }
            public Device()
            {
                this.id = new Guid();
                this.faultList = new ObservableCollection<FaultViewModel>();
            }
            public Device(string name) : this()
            {
                this.name = name;
            }
        }
    }
