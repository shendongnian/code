    public class ReportViewer: UserControl
    {
        IAccount _Account;
        public ReportViewer(IAccount account)
        {  
             this._Account = account;
             InitializeComponent();
        }
        void btnClick_Print()
        {
            _Account.Visit(new PrintReportVisitor());
        }
        
        void btnClick_ViewReport()
        {
            _Account.Visit(new DisplayReportVisitor(this));
        }
        
        void btnClick_SendSMS()
        {
            _Account.Visit(new SMSReportVisitor(this));
        }
        
        void btnClick_SendEmail()
        {
            _Account.Visit(new EmailReportVisitor(this));
        }
    }
