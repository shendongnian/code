    public partial class Form1 : Form
    {
        private WebBrowser wb1;
        private WebBrowser wb2;
        private WebBrowser wb3;
        public Form1()
        {
            wb1 = new WebBrowser();
            wb1.Navigate("https://www.google.com/");
            wb2 = new WebBrowser();
            wb2.Navigate("https://stackoverflow.com/");
            wb3 = new WebBrowser();
            wb3.Navigate("https://en.wikipedia.org/wiki/Main_Page");
            List<WebBrowser> lwb = new List<WebBrowser>();
            lwb.Add(wb1);
            lwb.Add(wb2);
            lwb.Add(wb3);
            foreach (WebBrowser wb in lwb)
            {
                wb.Dock = System.Windows.Forms.DockStyle.Fill;
                wb.Location = new System.Drawing.Point(0, 0);
                wb.MinimumSize = new System.Drawing.Size(20, 20);
                wb.Name = "webBrowser1";
                wb.Size = new System.Drawing.Size(260, 208);
                wb.TabIndex = 0;
            }
            InitializeComponent();
        }
        private void bringToFront(WebBrowser wb)
        {
            this.panel1.Controls.Remove(this.webBrowser1);
            this.webBrowser1 = wb;
            this.panel1.Controls.Add(this.webBrowser1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bringToFront(wb1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bringToFront(wb2);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            bringToFront(wb3);
        }
    }
