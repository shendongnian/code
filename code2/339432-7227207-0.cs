    and finaly I added code to change the buttons text to "clicked" into the codebehind:
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace StackOverflowHelp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                // the following line is from InitializeComponent - here you can see how the eventhandler is hook
                // this.button1.Click += new System.EventHandler(this.OnButton1Clicked);
            }
    
            private void OnButton1Clicked(object sender, EventArgs e)
            {
                var button = sender as Button; // <- same as button1
                if (button == null) return; // <- should never happen, but who is to know?
                button.Text = "clicked";
            }
        }
    }
