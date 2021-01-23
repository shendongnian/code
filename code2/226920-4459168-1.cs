        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Net;
        using System.Net.Sockets;
        using System.IO;
        public class TcpCommunication
        	{
        		private TcpListener commListener;
        		private TcpClient client;
        		private StreamReader reader;
        	
        		public TcpCommunication(int port)
        		{
        			this.commListener = new TcpListener(new IPAddress(new byte[]{127,0,0,1}),port);
        		}
        
        		public bool isAlive()
        		{
        			return client != null && this.client.Connected;
        		}
        
        		public void waitForClient()
        		{
        			this.commListener.Start();
        			this.client = commListener.AcceptTcpClient();
        			this.reader = new StreamReader(client.GetStream());
        			this.commListener.Stop();
        		}
        
        		public String getStringLine()
        		{
        			return reader.ReadLine();
        		}
        
        		public void writeStringLine(String commString)
        		{
        			commString = commString.Replace('\n','\t');
        
        			NetworkStream networkStream = client.GetStream();
        			System.Text.UTF8Encoding encoding = new UTF8Encoding(); 
        			Byte[] stringInByteFormat = encoding.GetBytes(commString + "\n");        			networkStream.Write(stringInByteFormat,0,stringInByteFormat.Length);
    	                }
