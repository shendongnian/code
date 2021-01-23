    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    public class Form1 : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    
        public Form1()
        {
            Controls.Add(new Label { Text = "Name", Location = new Point(10, 10), AutoSize = true });
            Controls.Add(new TextBox { Name = "Name", Location = new Point(60, 10) });
            Controls.Add(new Label { Text = "Date", Location = new Point(10, 40), AutoSize = true });
            Controls.Add(new DateTimePicker { Name = "Date", Location = new Point(60, 40) });
            Controls.Add(new Button { Name = "Submit", Text = "Submit", Location = new Point(10, 70) });
            Controls.Add(new CheckedListBox { Name = "List", Location = new Point(10, 100), Size = new Size(ClientSize.Width - 20, ClientSize.Height - 100 - 10) });
            Controls["Submit"].Click += (s, e) =>
                    (Controls["List"] as CheckedListBox).Items.Add(new MyItem { Name = Controls["Name"].Text, Date = (Controls["Date"] as DateTimePicker).Value });
        }
    }
    
    public class MyItem
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
    
        public override string ToString()
        {
            return String.Format("{0} {1}", Name, Date);
        }
    }
