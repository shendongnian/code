    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            DoubleBuffered = true;
            AllowTransparency = true;
            BackColor = Color.Black;
            Opacity = .5;
        }
    }
    
