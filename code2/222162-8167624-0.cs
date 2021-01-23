    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace CustomControl
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //add a handle to the property changed event
            myButton1.OnNameChanged += new EventHandler(myButton1_OnNameChanged);
        }
        void myButton1_OnNameChanged(object sender, EventArgs e)
        {
            MessageBox.Show("My Name Changed");
        }
    }
    public class myButton : Button
    {
        private string _Name = "";
        public event EventHandler OnNameChanged;
        public string myName
        {
            get { return _Name; }
            set
            {
                _Name = value;
                if (OnNameChanged != null)
                    OnNameChanged(this,EventArgs.Empty);
                //just for Demonstrative purposes I added this so you could see the _Name actually change
                this.Text = _Name;
            }
        }
        //added this to demonstrate the name changing 
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            myName = "my New Name";
        }
    }
    }
