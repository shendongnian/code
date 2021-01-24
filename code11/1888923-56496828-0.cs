    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp
    {
        public partial class Form1 : Form
        {
            private const string mouseIsOver = "Mouse is over";
            private const string mouseIsOutside = "Mouse is outside";
    
            public Form1()
            {
                InitializeComponent();
                var button = new Button { Text = mouseIsOutside, AutoSize = true, Location = new Point(10, 10) };
                button.MouseEnter += (sender, e) => button.Text = mouseIsOver;
                button.MouseLeave += (sender, e) => button.Text = mouseIsOutside;
                this.Controls.Add(button);
    
            }
        }
    }
