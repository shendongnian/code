using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;      //required
using System.Net.Sockets;    //required
namespace ServerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 9999);  
           // we set our IP address as server's address, and we also set the port: 9999
            server.Start();  // this will start the server
            while (true)   //we wait for a connection
            {
                TcpClient client = server.AcceptTcpClient();  //if a connection exists, the server will accept it
                NetworkStream ns = client.GetStream(); //networkstream is used to send/receive messages
                byte[] hello = new byte[100];   //any message must be serialized (converted to byte array)
                hello = Encoding.Default.GetBytes("hello world");  //conversion string => byte array
                ns.Write(hello, 0, hello.Length);     //sending the message
                while (client.Connected)  //while the client is connected, we look for incoming messages
                {
                    byte[] msg = new byte[1024];     //the messages arrive as byte array
                    ns.Read(msg, 0, msg.Length);   //the same networkstream reads the message sent by the client
                    Console.WriteLine(encoder.GetString(msg).Trim('')); //now , we write the message as string
                }
            }
## Create an api to communicate
The options are unlimited. Create a rest api using WebApi 2 or any other technology to periodically hit and check for data updates.
This communication is asynchronous and not direct,  so you should account for that in some way.
## Use push notifications
Mobile applications can get push notifications. If the communication is not bidirectional, this on its own could be a solution. 
If it is, then the mobile application could communicate via an api and the forms application via push notifications 
Check https://gamedev.stackexchange.com/questions/157009/how-can-i-send-android-notifications-from-my-unity-game#
