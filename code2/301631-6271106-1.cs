    public partial class ReportDateControl : System.Web.UI.UserControl
    {
        public event EventHandler UpdateReport;
        public string FromDate
        {
            get { return this.FromDateTextBox.Text; }
            set { this.FromDateTextBox.Text = value; }
        }
        public string ToDate
        {
            get { return this.ToDateTextBox.Text; }
            set { this.ToDateTextBox.Text = value; }
        }
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (UpdateReport != null)
            {
                UpdateReport(this, EventArgs.Empty);
            }
        }
    }
