    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    
    namespace MiscApp
    {
        public partial class Form1 : Form
        {
            private Stopwatch globalTimer = new Stopwatch();
            private long myStamp1 = 0;
            public Form1()
            {
                InitializeComponent();
                globalTimer.Start();
            }
    
            private void SomeFunction()
            {
                if (globalTimer.ElapsedMilliseconds - myStamp1 >= 3000)
                {
                    myStamp1 = globalTimer.ElapsedMilliseconds;
                    //Do something here...
                }
            }
        }
    }
