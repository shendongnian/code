    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace eventsC
    {    
    
        public partial class Form1 : Form
        {
    
            public static event EventHandler<EventArgs> myEvent;
    
            protected void OnMyEvent()
            {
                if (myEvent != null)
                    myEvent(this, EventArgs.Empty);
            }
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                myEvent += Handler;
    
                //call all methods that have been added to the event
                myEvent(this, EventArgs.Empty);
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                OnMyEvent();
            }
           
    
            static void Handler(object sender, EventArgs args)
            {
                Console.WriteLine("Event Handled!");
            }
    
        }
    }
