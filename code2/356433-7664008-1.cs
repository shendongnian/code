    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1() {InitializeComponent();}
            private bool _isLeftPanelBig;
            private void PanelLeftClick(object sender, EventArgs e)
            {
                panelLeft.Size = _isLeftPanelBig ? new Size(80, 300) : new Size(500, 300);
                _isLeftPanelBig = !_isLeftPanelBig;
            }
        }
    }
