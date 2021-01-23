    using System;
    using System.Windows.Forms;
    namespace Test
    {
        public class Form1 : Form
        {
            public Form1()
            {
                var dateSelectionButton = new Button();
                SuspendLayout();
                dateSelectionButton.Text = "Pick Date";
                dateSelectionButton.Click += (SelectDateClick);
                Controls.Add(dateSelectionButton);
                ResumeLayout();
            }
            private void SelectDateClick(object sender, EventArgs e)
            {
                MonthCalendar cal = new MonthCalendar();
                Form f = new Form();
                cal.DateSelected += DateSelected;
                f.Controls.Add(cal);
                f.Show();
            }
            void DateSelected(object sender, DateRangeEventArgs e)
            {
                MonthCalendar cal = (MonthCalendar)sender;
                Form f = cal.FindForm();
                f.Close();
            }
        }
    }
