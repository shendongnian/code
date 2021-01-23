    using System;
    using System.Windows.Forms;
    using System.IO;
    using System.IO.Ports;
    namespace SerialPortExample {
        public partial class Form1 : Form {
            SerialPort myport;
            public Form1() {
                InitializeComponent();
                myport = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
                myport.DataReceived += new SerialDataReceivedEventHandler(myport_DataReceived);
                myport.ErrorReceived += new SerialErrorReceivedEventHandler(myport_ErrorReceived);
            }
            void myport_ErrorReceived(object sender, SerialErrorReceivedEventArgs e) {
                MessageBox.Show("Error recieved: " + e.EventType);
            }
            void myport_DataReceived(object sender, SerialDataReceivedEventArgs e) {
                textBox1.Text = myport.ReadExisting();
            }
            private void button1_Click(object sender, EventArgs e) {
                try {
                    if (myport.IsOpen) {
                        myport.Close();
                        button1.Text = "Start";
                    } else {
                        myport.Open();
                        button1.Text = "Stop";
                    }
                } catch (IOException ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
