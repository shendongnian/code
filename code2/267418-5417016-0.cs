    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Net.Sockets;
    public class SimpleTcpClient {
        public static void Main() {
            			
            TcpClient tcpclnt = new TcpClient();            
            tcpclnt.Connect("10.100.200.1",30000);
            			
            String textToSend = "HelloWorld!";
            Stream stm = tcpclnt.GetStream();
                        
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] data = asen.GetBytes(textToSend);
            
            stm.Write(data,0,data.Length);
            
			//You might want to wait a bit for an answer (Thread.Sleep or simething)
			
            byte[] responseData = new byte[1024];
            string textRecevided = "";
			int read = 0;				
			do {  
				read = stm.Read(responseData, 0, responseData.Length);
                for (int i=0; i < read; i++)
				{
					textRecevided += (char)responseData[i];
				}			
            } while (read > 0);
                        
            Console.Write(textRecevied);
            
            tcpclnt.Close();
        }
                       
    }
