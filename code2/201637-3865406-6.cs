    using System.Windows;
    using System.Windows.Controls;
    namespace GridMeasureExample
    {
        class InfoGrid : Grid
        {
            protected override Size ArrangeOverride(Size arrangeSize)
            {
                CallReportInfoEvent("Arrange");
                return base.ArrangeOverride(arrangeSize);
            }
            protected override Size MeasureOverride(Size constraint)
            {
                CallReportInfoEvent("Measure");
                return base.MeasureOverride(constraint);
            }
            public event EventHandler<InfoGridEventArgs> ReportInfo;
            private void CallReportInfoEvent(string message)
            {
                if (ReportInfo != null)
                    ReportInfo(this, new InfoGridEventArgs(message));
            }
        }
        public class InfoGridEventArgs : EventArgs
        {
            private InfoGridEventArgs()
            {
            }
            public InfoGridEventArgs(string message)
            {
                this.TimeStamp = DateTime.Now;
                this.Message = message;
            }
            public DateTime TimeStamp
            {
                get;
                private set;
            }
            public String Message
            {
                get;
                private set;
            }
        }
    }
