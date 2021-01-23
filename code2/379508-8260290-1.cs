    public partial class frmCalendar : Form
        {
            bool activated;
            public frmCalendar()
            {
                InitializeComponent();
                activated = true;
            }
            public bool  formOpened
            {
                get
                {
                    return activated;
                }
            }
            public DateTime quarterEndDate
            {
                get 
                {
                    return mcUserDate.Value;
                }
                set 
                {
                    mcUserDate.Value = value;
                }
            }
        }
