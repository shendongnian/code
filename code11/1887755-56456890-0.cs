    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp3
    {
        public partial class Form1 : Form
        {
            private TcpListener listener;
    
            private delegate void StringVoidInvoker(string value);
    
            public Form1()
            {
                InitializeComponent();
            }
    
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
    
                // it is better to start your thread when the UI controls are just one step away from being created
    
                Thread t = new Thread(() =>
                {
                    ListenTCPPort();
                });
    
                // this way, closing the form closes the thread. this is a bad practice, since you should be using a more reliable method to close the thread (e.g. events and waithandles)
                t.IsBackground = true;
                t.Start();
    
            }
    
            private void SafeLog(string value)
            {
                if (this.InvokeRequired)
                {
                    // if we are being called between threads, we have to ask the original UI thread to perfom the task
                    this.Invoke(new StringVoidInvoker(SafeLog), new object[] { value });
                }
                else
                {
                    this.listBox1.Items.Add(value);
                }
            }
    
            public void ListenTCPPort()
            {
                string ipAddress, portNumber, mqName;
                ipAddress = ConfigurationManager.AppSettings.Get("IP").ToString().Trim();
                portNumber = ConfigurationManager.AppSettings.Get("PORT").ToString().Trim();
                mqName = ConfigurationManager.AppSettings.Get("MSMQ").ToString().Trim();
                int j;
                int port = Int32.TryParse(portNumber, out j) ? j : 0;
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddress.ToString()), port);
    
                listener = new TcpListener(ep);
                listener.Start();
    
    
                SafeLog("Started listening requests at: " + ipAddress.ToString() + ":" + portNumber.ToString());
    
                while (true)
                {
                    try
                    {
                        const int bytesize = 1024 * 1024;
                        string message = null;
                        byte[] buffer = new byte[bytesize];
    
                        TcpClient sender = listener.AcceptTcpClient();
    
                        sender.GetStream().Read(buffer, 0, bytesize);
    
    
                        message = cleanMessage(buffer);
    
                        byte[] bytes = System.Text.Encoding.Default.GetBytes(message);
    
                        string data = System.Text.Encoding.Default.GetString(bytes);
    
    
                        SafeLog("Incoming : " + data.ToString());
    
                        string output = sendMessage(data, sender, mqName);
                        SafeLog(output);
                        sender.Close();
    
                    }
                    catch (Exception e)
                    {
                        SafeLog("Exception : " + e.ToString());
                    }
                }
            }
    
            private string sendMessage(string data, TcpClient sender, string mqName)
            {
                // place here your logic
                return "NOTIMPL";
            }
    
            private string cleanMessage(byte[] buffer)
            {
                // place here your logic
                return "NOTIMPL";
            }
        }
    }
