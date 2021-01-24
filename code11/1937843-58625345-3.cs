    using WpfApp1.Models;
    namespace WpfApp1
    {
        public class FaultViewModel : ViewModelBase<Fault>
        {
            public string Name
            {
                get { return Model.FaultName; }
                set
                {
                    Model.FaultName = value;
                    RaisePropertyChanged("Name");
                }
            }
            public string Id
            {
                get { return Model.FaultId.ToString(); }
            }
            public FaultViewModel() : base(new Fault())
            {
            }
        }
    }
    using System;
    namespace WpfApp1.Models
    {
        public class Fault
        {
            private Guid faultId;
            private string faultName;
            public Guid FaultId
            {
                get { return faultId; }
                set { faultId = value; }
            }
            public string FaultName
            {
                get { return faultName; }
                set { faultName = value; }
            }
            public Fault()
            {
                this.faultId = new Guid();
            }
        }
    }
