    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.IsMdiContainer = true;
            foreach (Control ctl in this.Controls) {
                if (ctl is MdiClient) {
                    ctl.BackgroundImage = Properties.Resources.Chrysanthemum;
                    ctl.BackgroundImageLayout = ImageLayout.Center;   // doesn't work
                    break;
                }
            }
        }
    }
