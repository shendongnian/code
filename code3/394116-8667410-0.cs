    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace test
    {
    public partial class Form1 : Form
    {
        List<string> LastData = new List<string>();
        int undoCount = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LastData.Add(richTextBox1.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = LastData[LastData.Count - undoCount - 1];
                ++undoCount;
            }
            catch { }
        }
        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            LastData.Add(richTextBox1.Text);
            undoCount = 0;
        }
    }
    }
