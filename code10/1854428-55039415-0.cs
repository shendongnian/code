    public interface IReport
    {
        int  ReportId { get;  }
    }
    
    public class PaymentReport : IReport
    {
        public int PaymentReportId { get; set; }
        public int ReportId
        {
            get => PaymentReportId;
        }
    }
