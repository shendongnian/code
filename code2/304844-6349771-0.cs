    //Code for the main form:
    namespace WinAlignTest {
        public partial class Form1 : Form {
            public Form1() {
                InitializeComponent();
                tabControl1.TabPages[0].Controls.Add(new SomeApplication());
            }
        }
    }
    
    //Code that shows the option window
    namespace WinAlignTest {
        public partial class SomeApplication : UserControl {
            private ApplicationOptions Options;
            public SomeApplication() {
                InitializeComponent();
                Options = new ApplicationOptions();
            }
    
            private void button1_Click(object sender, EventArgs e) {
                Options.Show();
    
                // You might need to use PointToScreen here
                Options.Location = this.Location;
            }
        }
    }
