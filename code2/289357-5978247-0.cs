    public partial class Form1 : Form
        {
            Form f = new Form();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void showcalendar_Click(object sender, EventArgs e)
            {
                ShowCalendar();
            }
    
            void ShowCalendar()
            {
                DateTime current5 = DateTime.Now.AddDays(-5);
    
                MonthCalendar cal = new MonthCalendar();
                Panel panel = new Panel();
                  
                cal.MaxSelectionCount = 1;
                cal.SetDate(current5);
                cal.DateSelected += new DateRangeEventHandler(DateSelected);
                cal.ShowToday = true;
                panel.Width = cal.Width;
                panel.Height = cal.Height;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Controls.Add(cal);
                f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                f.ShowInTaskbar = false;
                f.Size = panel.Size;
                f.Location = MousePosition;
                f.StartPosition = FormStartPosition.Manual;
                f.Controls.Add(panel);
                f.Deactivate += delegate { f.Hide(); };
                f.Show();
            }
            
            void DateSelected(object sender, DateRangeEventArgs e)
            {
                DateTime selection = e.Start;
                Console.WriteLine("Selected: {0}", selection.ToLongDateString());
    
                this.Activate(); // Forces popup to de-activate
            }
    
        }
