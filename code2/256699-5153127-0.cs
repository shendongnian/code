using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
namespace Base.BaseObjects
{
    public class AsynchronousClient
    {
        #region Properties
        private int _port = 0000, currentTry = 0, _buffersize, _fastpingdelay = 80;
        private string _server = &quot;localhost&quot;;
        private Socket client;
        private static IPEndPoint remoteEP;
        // Delegates &amp; Events
        public delegate void SendMessageDelegate(string message);
        public event SendMessageDelegate SendMessageEvent;
        public delegate void ConnectionStatusDelegate(bool connected, bool reconnect);
        public event ConnectionStatusDelegate ConnectionStatusChanged;
        // ManualResetEvent instances signal completion.
        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);
        /// &lt;summary&gt;
        /// Port to monitor
        /// &lt;/summary&gt;
        public int Port { get { return _port; } }
        /// &lt;summary&gt;
        /// Number of packages to buffer until system reports connection loss
        /// &lt;/summary&gt;
        public int BufferSize { get { return _buffersize; }  }
        /// &lt;summary&gt;
        /// Time in milliseconds between two pings
        /// &lt;/summary&gt;
        public int FastPingDelay { get { return _fastpingdelay; } }
        /// &lt;summary&gt;
        /// Servername to connect to
        /// &lt;/summary&gt;
        public string Server
        {
            get { return _server; }
            set
            {
                _server = value;
                // Resolve the remote endpoint for the socket.
                try
                {
                    IPAddress ipAddress = (IPAddress)Dns.GetHostAddresses(value)[0];
                    remoteEP = new IPEndPoint(ipAddress, Port);
                }
                catch (SocketException ex)
                {
                    SendMessage(ex.Message);
                }
            }
        }
        #endregion
        #region Events &amp; Delegates
        protected void SendMessage(string message)
        {
            if (SendMessageEvent != null)
                SendMessageEvent(message);
        }
        protected void UpdateConnectionStatus(bool connected, bool reconnect)
        {
            if (ConnectionStatusChanged != null)
                ConnectionStatusChanged(connected, reconnect);
        }
        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;
                // Complete the connection.
                client.EndConnect(ar);
                SendMessage(String.Format(&quot;Socket connected to {0}&quot;, client.RemoteEndPoint.ToString()));
                //UpdateConnectionStatus(true, false);
                // Signal that the connection has been made.
                connectDone.Set();
            }
            catch (Exception e)
            {
                SendMessage(e.ToString());
                UpdateConnectionStatus(false, true);
            }
        }
        #endregion
        #region methods
        public AsynchronousClient(int port, string server)
        {
            _port = port;
            Server = server;
            _buffersize = 10;
            _fastpingdelay = 20;
        }
        public void CreateSocket()
        {
            try
            {
                StopClient();
            }
            catch (Exception ex)
            {
                SendMessage(ex.Message);
            }
            finally
            {
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
        }
        public bool FastPingSocket()
        {
            for (currentTry = 0; currentTry &lt;= BufferSize; currentTry++)
            {
                try
                {
                    CreateSocket();
                    client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);
                    connectDone.WaitOne();
                    System.Threading.Thread.Sleep(FastPingDelay);
                    client.Shutdown(SocketShutdown.Receive);
                    connectDone.WaitOne();
                    client.Close();
                    return true;
                }
                catch (SocketException ex)
                {
                    SendMessage(ex.Message);
                }
                catch (ObjectDisposedException ex)
                {
                    currentTry--;
                    SendMessage(ex.Message);
                    CreateSocket();
                }
                catch (NullReferenceException ex)
                {
                    currentTry--;
                    SendMessage(ex.Message);
                    CreateSocket();
                }
                catch (ArgumentNullException ex)
                {
                    SendMessage(ex.Message);
                    CreateSocket();
                }
                catch (InvalidOperationException ex)
                {
                    SendMessage(ex.Message);
                    CreateSocket();
                    currentTry--;
                }
                finally
                {
                    StopClient();
                }
            }
            UpdateConnectionStatus(false, true);
            return false;
        }
        public void StopClient()
        {
            // Release the socket.
            try
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (Exception) { }
            finally
            {
                UpdateConnectionStatus(false, false);
            }
        }
        #endregion
    }
}
