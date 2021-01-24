    using Prism.Events;
    using Prism.Mvvm;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ManualControls
    {
        public class ResultBarViewModel : BindableBase
        {
            private string testStatus { get; set; }
            private double? min { get; set; }
            private double? max { get; set; }
            private double? resultvalue { get; set; }
            private string title { get; set; }
            private string unit { get; set; }
            private readonly IEventAggregator _eventAggregator;
    
            public ResultBarViewModel(IEventAggregator eventAggregator)
            {
                _eventAggregator = eventAggregator;
                _eventAggregator.GetEvent<ReadDataEvent>().Subscribe(RefreshResultData);
            }
    
            private void RefreshResultData(ReadDataPayload payload)
            {
    
            }
    
            public string TestStatus
            {
                get
                {
                    return testStatus;
                }
                set
                {
                    testStatus = value;
                    RaisePropertyChanged();
                }
            }
            public double? Min
            {
                get { return min; }
                set { min = value; }
            }
            public double? Max
            {
                get { return max; }
                set { max = value; }
            }
            public double? Value
            {
                get
                {
                    return resultvalue;
                }
                set
                {
                    resultvalue = value;
                    RaisePropertyChanged();
                }
            }
            public string Title
            {
                get
                {
                    return title;
                }
                set
                {
                    title = value;
                }
            }
            public string Unit
            {
                get
                {
                    return unit;
                }
                set
                {
                    unit = value;
                }
            }
        }
    }
