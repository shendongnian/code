        public class DatePickerForm : Form
        {
            public DatePickerForm()
            {
                InitializeComponent();
            }
     
            private void calendar_DateSelected(object sender, DateRangeEventArgs e)
            {
                this.Close();
            }
        }
