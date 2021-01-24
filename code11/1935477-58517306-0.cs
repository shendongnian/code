using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace tcplistenertest
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread listenerThread = StartBackgroundThread(new ThreadStart(ThreadProc));
            while(Console.ReadLine() != string.Empty)
            {
            }
            mListener.Stop();
            listenerThread.Join();
        }
        static void ThreadProc()
        {
            try
            {
                mListener = StartListening();
                AcceptLoop(mListener);
            }
            catch(Exception e)
            {
                Console.WriteLine($"ThreadProc error: {e.Message}");
                Console.WriteLine($"Stack trace:{Environment.NewLine}{e.StackTrace}");
            }
        }
        static Thread StartBackgroundThread(ThreadStart task)
        {
            Thread thread = new Thread(task);
            thread.IsBackground = true;
            thread.Start();
            return thread;
        }
        static TcpListener StartListening()
        {
            TcpListener result = new TcpListener(IPAddress.Any, PORT);
            result.Start();
            return result;
        }
        static void AcceptLoop(TcpListener listener)
        {
            // this is the main loop of the Socket based server
            while (true)
            {
                Socket socket = null;
                try
                {
                    Console.WriteLine("Accepting connection...");
                    socket = AcceptConnection(listener);
                    Console.WriteLine($"Connection accepted from {socket.RemoteEndPoint}");
                }
                catch (SocketException e)
                {
                    Console.WriteLine($"Socket error accepting connection: {e.Message}");
                    Console.WriteLine($"Stack trace:{Environment.NewLine}{e.StackTrace}");
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Generic error accepting connection: {e.Message}");
                    Console.WriteLine($"Stack trace:{Environment.NewLine}{e.StackTrace}");
                    break;
                }
                try
                {
                    socket.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error closing socket: {e.Message}");
                    Console.WriteLine($"Stack trace:{Environment.NewLine}{e.StackTrace}");
                    break;
                }
            }
            Console.WriteLine("Accept loop thread stopping");
        }
        static Socket AcceptConnection(TcpListener listener)
        {
            Socket socket = listener.AcceptSocket();
            try
            {
                socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.Debug, 1);
                LingerOption optionValue = new LingerOption(true, 3);
                socket.SetSocketOption(SocketOptionLevel.Socket,
                    SocketOptionName.Linger, optionValue);
                return socket;
            }
            catch (Exception)
            {
                socket.Close();
                throw;
            }
        }
        static TcpListener mListener;
        const int PORT = 55000;
    }
}
