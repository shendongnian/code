    using System;
    using System.Windows.Forms;
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            for (int i=0; i<250; i++) listBox1.Items.Add("item " + i);
        }
        private void Label1MouseDown(object sender, MouseEventArgs e) {
            Cursor.Current = Cursors.SizeAll;
        }
    }
