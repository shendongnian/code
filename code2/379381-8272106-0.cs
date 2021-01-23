    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using Microsoft.SPOT;
    using System.Threading;
    using System;
    
    namespace EPI.Net
    {
        public class EfficientPutRequest
        {
            #region MysSettings        
            static string _server;
            static int httpPort;
            static string _name;
            static string _namespace = "http://tempuri.org/";
            static string _event = "CreateEvent";
            #endregion
    
            public static Socket connection;
    
    
            public EfficientPutRequest(string uri)
            {
                Uri siteUri = new Uri(uri);
                _server = siteUri.Host;
                _name = siteUri.AbsolutePath;
                httpPort = siteUri.Port;
                connection = Connect(_server, 5000);
            }
    
            static Socket Connect(string host, int timeout)
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(host);
    
                IPAddress hostAddress = hostEntry.AddressList[0];
                IPEndPoint remoteEndPoint = new IPEndPoint(hostAddress, httpPort);
    
                var connection = new Socket(AddressFamily.InterNetwork,  SocketType.Stream, ProtocolType.Tcp);
                connection.Connect(remoteEndPoint);
                connection.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.Linger, new byte[] { 0, 0, 0, 0 });
                connection.SendTimeout = timeout;
                return connection;
            }
    
            public void SendRequest(System.DateTime timestamp, string args)
            {
                const string CRLF = "\r\n";
    
                string content =
                    "<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
                    "<s:Body>" +
                    "<" + _event + " xmlns=\"" + _namespace + "\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                    "<timestamp>" + timestamp.ToString("yyyy-MM-ddTHH:mm:ss") + "</timestamp>" +
                    "<Args>" + args + "</Args>" +
                    "</" + _event + ">" +
                    "</s:Body>" +
                    "</s:Envelope>";
                byte[] contentBuffer = Encoding.UTF8.GetBytes(content);
    
                var requestLine =
                    "POST " + _name + " HTTP/1.1" + CRLF;
                byte[] requestLineBuffer = Encoding.UTF8.GetBytes(requestLine);
    
                var headers =
                    "Content-Type: text/xml; charset=utf-8" + CRLF +
                    "SOAPAction: \"" + _namespace + _event + "\"" + CRLF +
                    "Host: " + _server + CRLF +
                    "Content-Length: " + contentBuffer.Length + CRLF +
                    "Expect: 100-continue" + CRLF +
                    "Accept-Encoding: gzip, deflate" + CRLF + CRLF;
                byte[] headersBuffer = Encoding.UTF8.GetBytes(headers);
                try
                {
                    connection.Send(requestLineBuffer);
                    Thread.Sleep(100);
                    connection.Send(headersBuffer);
                    Thread.Sleep(100);
                    connection.Send(contentBuffer);
                    Thread.Sleep(100);
                    connection.Close();
                }
            }
        }
    }
