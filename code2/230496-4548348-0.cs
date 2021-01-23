    using System;
    using System.Windows.Forms;
    namespace Bling
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                dateTimePicker.MaxDate = DateTime.Now;
            }
        }
    }
