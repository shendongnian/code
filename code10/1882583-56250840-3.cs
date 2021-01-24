Description					HEX		ASCII	Symbol
Message starting character	0B		11		<VT>
Message ending characters	1C,0D	28,13	<FS>,<CR>
This way, when you send a message to Listener (TCP/MLLP server), it looks for Start Block in your incoming data. It never finds it. It just discards your entire message considering garbage. Hence, you get nothing back from Listener.
With MLLP implemented, your message (the stuff you are writing on socket) should look _something_ like below:
    <VT>MSH|^~\\&|TestAppName||AVR||20181107201939.357+0000||QRY^R02^QRY_R02|923456|P|2.5<FS><CR>
Note the `<VT>`, `<CR>` and `<FS>` are place holders in above message.
You may refer to [this](https://saravanansubramanian.com/hl72xdotnetprogramming/) article for detailed information (Read step 4 and onward):
>     using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    namespace SimpleMllpHl7ClientAdvanced
    {
        public class Program
        {
            private static char END_OF_BLOCK = '\u001c';
            private static char START_OF_BLOCK = '\u000b';
            private static char CARRIAGE_RETURN = (char)13;
            static void Main(string[] args)
            {
                TcpClient ourTcpClient = null;
                NetworkStream networkStream = null;
                var testHl7MessageToTransmit = new StringBuilder();
                //a HL7 test message that is enveloped with MLLP as described in my article
                testHl7MessageToTransmit.Append(START_OF_BLOCK)
                    .Append("MSH|^~\\&|AcmeHIS|StJohn|CATH|StJohn|20061019172719||ORM^O01|MSGID12349876|P|2.3")
                    .Append(CARRIAGE_RETURN)
                    .Append("PID|||20301||Durden^Tyler^^^Mr.||19700312|M|||88 Punchward Dr.^^Los Angeles^CA^11221^USA|||||||")
                    .Append(CARRIAGE_RETURN)
                    .Append("PV1||O|OP^^||||4652^Paulson^Robert|||OP|||||||||9|||||||||||||||||||||||||20061019172717|20061019172718")
                    .Append(CARRIAGE_RETURN)
                    .Append("ORC|NW|20061019172719")
                    .Append(CARRIAGE_RETURN)
                    .Append("OBR|1|20061019172719||76770^Ultrasound: retroperitoneal^C4|||12349876")
                    .Append(CARRIAGE_RETURN)
                    .Append(END_OF_BLOCK)
                    .Append(CARRIAGE_RETURN);
                try
                {
                    //initiate a TCP client connection to local loopback address at port 1080
                    ourTcpClient = new TcpClient();
                    ourTcpClient.Connect(new IPEndPoint(IPAddress.Loopback, 1080));
                    Console.WriteLine("Connected to server....");
                    //get the IO stream on this connection to write to
                    networkStream = ourTcpClient.GetStream();
                    //use UTF-8 and either 8-bit encoding due to MLLP-related recommendations
                    var sendMessageByteBuffer = Encoding.UTF8.GetBytes(testHl7MessageToTransmit.ToString());
                    if (networkStream.CanWrite)
                    {
                        //send a message through this connection using the IO stream
                        networkStream.Write(sendMessageByteBuffer, 0, sendMessageByteBuffer.Length);
                        Console.WriteLine("Data was sent data to server successfully....");
                        var receiveMessageByteBuffer = Encoding.UTF8.GetBytes(testHl7MessageToTransmit.ToString());
                        var bytesReceivedFromServer = networkStream.Read(receiveMessageByteBuffer, 0, receiveMessageByteBuffer.Length);
                        // Our server for this example has been designed to echo back the message
                        // keep reading from this stream until the message is echoed back
                        while (bytesReceivedFromServer > 0)
                        {
                            if (networkStream.CanRead)
                            {
                                bytesReceivedFromServer = networkStream.Read(receiveMessageByteBuffer, 0, receiveMessageByteBuffer.Length);
                                if (bytesReceivedFromServer == 0)
                                {
                                    break;
                                }
                            }                            
                        }
                        var receivedMessage = Encoding.UTF8.GetString(receiveMessageByteBuffer);
                        Console.WriteLine("Received message from server: {0}", receivedMessage);
                    }
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    //display any exceptions that occur to console
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    //close the IO strem and the TCP connection
                    networkStream?.Close();
                    ourTcpClient?.Close();
                }
            }
        }
    }
You should modify your following line of code as below:
    var req = START_OF_BLOCK + "MSH|^~\\&|TestAppName||AVR||20181107201939.357+0000||QRY^R02^QRY_R02|923456|P|2.5" + END_OF_BLOCK + CARRIAGE_RETURN;
For more open source code, you may refer to [this](https://github.com/dib0/HL7Fuse) github project.
