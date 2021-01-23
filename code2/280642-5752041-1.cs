     using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace ProjectTest
    {
       public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Close();
        }
    
        private void Form1_FormClosing()
       {
       const string message =
        "There's an updated version of this program available. Would you like to download now?";
    const string caption = "Please update";
    var result = MessageBox.Show(message, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
    
    // If the no button was pressed ...
    if (result == DialogResult.No)
    {
        MessageBox.Show("Program will close now. If you want to use this program please update to the newest version.", "Please update");
                    e.Cancel = false;
    }
    else if (result == DialogResult.Yes)
    {
        System.Diagnostics.Process.Start("http://www.google.com");
                    e.Cancel = false;
    }
    }
    
        }
    }
