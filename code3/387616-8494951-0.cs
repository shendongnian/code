    using System;
    using System.Collections.Generic;
    using System.ComponentModel;  
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var back = new BackgroundWorker();
            back.DoWork += new DoWorkEventHandler(back_DoWork);
            back.RunWorkerCompleted += new  RunWorkerCompletedEventHandler(back_RunWorkerCompleted);
            back.RunWorkerAsync();
        }
        //Do work here (not safe to call control elemnts here - if so, use this.invoke(deligate);
        private decimal myResult = 0;
        void back_DoWork(object sender, DoWorkEventArgs e)
        {
            myResult = 5 + 5;
        }
        //Update form here - threadsafe
        void back_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label1.Text = "result: " + myResult.ToString();
        }
    }
}
