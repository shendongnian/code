    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace Asseblies
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private System.Reflection.Assembly _assembly1 = null;
            private System.Reflection.Assembly _assembly2 = null;
            private void button1_Click(object sender, EventArgs e)
            {
                if (System.Object.Equals(_assembly1,null))
                {
                    _assembly1 = System.Reflection.Assembly.LoadFrom(@".\test1\test1.dll");
                }
                object inst = _assembly1.CreateInstance("Test1.Class1");
                inst.GetType().InvokeMember("SayHello", System.Reflection.BindingFlags.InvokeMethod, null, inst, null);
            
            }
            private void button2_Click(object sender, EventArgs e)
            {
                if (System.Object.Equals(_assembly2, null))
                {
                    _assembly2 = System.Reflection.Assembly.LoadFrom(@".\test2\test1.dll");
                }
                object inst = _assembly2.CreateInstance("Test1.Class1");
                inst.GetType().InvokeMember("SayHello", System.Reflection.BindingFlags.InvokeMethod, null, inst, null);
            }
        }
    }
