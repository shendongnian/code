    using System;
    using System.Drawing;
    using System.IO.Ports;
    using System.Windows.Forms;
    
    namespace SerialPortSample
    {
        public partial class Form1 : Form
        {
            private Timer timer1 = new Timer { Interval = 1000, Enabled = false }; // initialize timer, with a one second interval and disabled
            private Button startTimerButton = new Button { Name = "startTimerButton",Text = @"Toggle Timer", Size = new Size(130, 33), Location = new Point(0, 0) };
    
            // This is a place holder for the SerialPort control you probably have on your Form.
            //Remove this instance of serialPort1 and use the serialPort1 control from your form.
            private SerialPort serialPort1 = new SerialPort(); 
            public Form1()
            {
                InitializeComponent();
                // add button to Form
                this.Controls.Add(startTimerButton); // add button to form1
                startTimerButton.Click += StartTimerButton_Click;
                timer1.Tick += Timer1_Tick; // attach timer tick event
            }
    
            private void StartTimerButton_Click(object sender, EventArgs e)
            {
                timer1.Enabled = !timer1.Enabled; // toggle timer.endabled, if false the Tick event will not be raised
                    timer1.Interval = 1000; // set timer interval to 1000 so the next time it is enabled it triggers immediately.
            }
    
            private void Timer1_Tick(object sender, EventArgs e)
            {
                timer1.Interval = 60 * 60 * 1000; // set timer interval to 1 hour so it will not trigger for an hour 
    
                if (!serialPort1.IsOpen)
                    serialPort1.Open(); // open serial port if not open
    
                serialPort1.Write("high"); // write to the serial port
    
                serialPort1.Close(); // close serial port
            }
    
            
        }
    }
