using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
public static partial class TcpServer
{
    public static void Main()
    {
        // Setup listener on "localhost" port 12000
        IPAddress ipAddr = Dns.GetHostEntry("localhost").AddressList[0];
        TcpListener server = new TcpListener(ipAddr, 12000);
        server.Start(); // Network driver can now allow incoming requests 
        // Accept up to 1 client per CPU simultaneously
        Int32 numConcurrentClients = Environment.ProcessorCount;
        for (Int32 n = 0; n < numConcurrentClients; n++) new ClientConnectionApm(server);
        Console.WriteLine("Hit Enter to terminate the server.");
        Console.ReadLine();
    }
    private static Byte[] ProcessData(Byte[] inputData)
    {
        String inputString = Encoding.UTF8.GetString(inputData, 1, inputData[0]);
        String outputString = inputString.ToUpperInvariant();
        Console.WriteLine("Input={0}", inputString);
        Console.WriteLine("   Output={0}", outputString);
        Console.WriteLine();
        Byte[] outputStringBytes = Encoding.UTF8.GetBytes(outputString);
        Byte[] outputData = new Byte[1 + outputStringBytes.Length];
        outputData[0] = (Byte)outputStringBytes.Length;
        Array.Copy(outputStringBytes, 0, outputData, 1, outputStringBytes.Length);
        return outputData;
    }
}
public static partial class TcpServer
{
    private sealed class ClientConnectionApm
    {
        private TcpListener m_server;
        private TcpClient m_client;
        private Stream m_stream;
        private Byte[] m_inputData = new Byte[1];
        private Byte m_bytesReadSoFar = 0;
        public ClientConnectionApm(TcpListener server)
        {
            m_server = server;
            m_server.BeginAcceptTcpClient(AcceptCompleted, null);
        }
        private void AcceptCompleted(IAsyncResult ar)
        {
            // Connect to this client
            m_client = m_server.EndAcceptTcpClient(ar);
            // Accept another client
            new ClientConnectionApm(m_server);
            // Start processing this client
            m_stream = m_client.GetStream();
            // Read 1 byte from client which contains length of additional data
            m_stream.BeginRead(m_inputData, 0, 1, ReadLengthCompleted, null);
        }
        private void ReadLengthCompleted(IAsyncResult result)
        {
            // If client closed connection; abandon this client request
            if (m_stream.EndRead(result) == 0) { m_client.Close(); return; }
            // Start to read 'length' bytes of data from client
            Int32 dataLength = m_inputData[0];
            Array.Resize(ref m_inputData, 1 + dataLength);
            m_stream.BeginRead(m_inputData, 1, dataLength, ReadDataCompleted, null);
        }
        private void ReadDataCompleted(IAsyncResult ar)
        {
            // Get number of bytes read from client
            Int32 numBytesReadThisTime = m_stream.EndRead(ar);
            // If client closed connection; abandon this client request
            if (numBytesReadThisTime == 0) { m_client.Close(); return; }
            // Continue to read bytes from client until all bytes are in
            m_bytesReadSoFar += (Byte)numBytesReadThisTime;
            if (m_bytesReadSoFar < m_inputData.Length - 1)
            {
                m_stream.BeginRead(m_inputData, 1 + m_bytesReadSoFar,
                   m_inputData.Length - (m_bytesReadSoFar + 1), ReadDataCompleted, null);
                return;
            }
            // All bytes have been read, process the input data
            Byte[] outputData = ProcessData(m_inputData);
            m_inputData = null;  // Allow early GC
            // Write outputData back to client
            m_stream.BeginWrite(outputData, 0, outputData.Length,
               WriteDataCompleted, null);
        }
        private void WriteDataCompleted(IAsyncResult ar)
        {
            // After result is written to client, close the connection
            m_stream.EndWrite(ar);
            m_client.Close();
        }
    }
}
