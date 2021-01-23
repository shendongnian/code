    public partial class Form1 : Form
    {
        TabControl tc;
        public Form1()
        {
            InitializeComponent();
            tc = new TabControl();
           
            tc.TabPages.AddRange(new TabPage[]
            {
                new TabPage("tabPage 1"),
                new TabPage("tabPage 2")
            });
            tc.Location = new Point(20, 20);
            tc.Size = new Size(300, 200);
            this.ClientSize = new Size(350, 250);
            this.Controls.Add(tc);
            //renaming:
            this.tc.TabPages[0].Text = "1st tab";
            this.tc.TabPages[1].Text = "2nd tab";
            //changing background:
            this.tc.TabPages[0].BackColor = Color.Yellow;
            this.tc.TabPages[1].BackColor = Color.YellowGreen;
            //adding some controls to each tab:
            TextBox tb = new TextBox();
            tb.Location = new Point(20, 20);
            tb.Size = new Size(130, 20);
            tb.Text = "This textBox is on 1st tab";
            Label lb = new Label();
            lb.Location = new Point(20, 20);
            lb.Text = "This label is on 2nd tab";
            lb.ForeColor = Color.Red;
            this.tc.TabPages[0].Controls.Add(tb);
            this.tc.TabPages[1].Controls.Add(lb);
        }
    }
