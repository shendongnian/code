    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Net.NetworkInformation;
    using System.Collections;
    
    namespace ConsoleApplication1 {
    
        static class Program {
            //List used tcp port
            static void ListAvailableTCPPort(ref ArrayList usedPort) {
                IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
                TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
                IEnumerator myEnum = tcpConnInfoArray.GetEnumerator();
    
                while (myEnum.MoveNext()) {
                    TcpConnectionInformation TCPInfo = (TcpConnectionInformation)myEnum.Current;
                    Console.WriteLine("Port {0} {1} {2} ", TCPInfo.LocalEndPoint, TCPInfo.RemoteEndPoint, TCPInfo.State);
                    usedPort.Add(TCPInfo.LocalEndPoint.Port);
                }
            }
    
            public static void Main(){
                ArrayList usedPorts = new ArrayList();
                ListAvailableTCPPort(ref usedPorts);
                Console.ReadKey();
            }
        }
    }
