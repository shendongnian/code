    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace WindowsFormsApplication3
    {
        public delegate void MyDelagate();
    
        class Class1
        {
            public event MyDelagate _myDelegate;
            private String s1 = String.Empty;
    
            public String s
            {
                get
                {
                    return s1;
                }
    
                set
                {
                    s1 = value;
                    if(_myDelegate != null)
                        _myDelegate();
                }
            }
            public int DoOperation()
            {
                s = "Started";
                ReadTextFile();
                ParsingData();
                SaveTextFile();
                s = "Completed";
                return 0;
            }
            private int ReadTextFile()
            {
                s = "Read Text File";
                Thread.Sleep(3000);            
                return 0;
            }
            private int ParsingData()
            {
                s = "Parsing Data";
                Thread.Sleep(3000);
                return 0;
            }
            private int SaveTextFile()
            {
                s = "Save Text File";
                Thread.Sleep(3000);
                return 0;
            }
        }
    }
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            Class1 x = new Class1();
            
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                x._myDelegate += new MyDelagate(UpdateStatus);
                x.DoOperation();
            }
    
            void UpdateStatus()
            {
                label1.Text = x.s;
                Validate();
            }
        }
    }
