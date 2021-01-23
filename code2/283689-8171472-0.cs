    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace skttool
    {
        public class StateObject
        {
            public Socket workSocket = null;
            public const int BufferSize = 1024;
            public byte[] buffer = new byte[BufferSize];
            public int bytesRead = 0;
            public StringBuilder sb = new StringBuilder();
        }
    
        public class tool
        {
            //-------------------------------------------------
            private ManualResetEvent evtConnectionDone = new ManualResetEvent(false);
            private Socket skttool = null;
            private bool running = false;
            private StateObject state = null;
            //-------------------------------------------------
            toolConfig _cfg;
            public tool(toolConfig cfg)
            {
                _cfg = cfg;
            }
            //-------------------------------------------------
            public void socketListeningSet()
            {
                IPEndPoint localEndPoint;
                Socket skttool;
                byte[] bytes = new Byte[1024];
                localEndPoint = new IPEndPoint(IPAddress.Any, _cfg.addressPort);
                skttool = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                skttool.Bind(localEndPoint);
                skttool.Listen(_cfg.maxQtdSockets);
            }
            //-------------------------------------------------
            public void start()
            {
                running = true;
                Task T1 = Task.Factory.StartNew(socketListeningSet);
                T1.ContinueWith(prev =>
                {
                    while (running)
                    {
                        evtConnectionDone.Reset();
                        Task<Socket> accepetChunk = Task<Socket>.Factory.FromAsync(
                                                                           skttool.BeginAccept,
                                                                           skttool.EndAccept,
                                                                           accept,
                                                                           skttool,
                                                                           TaskCreationOptions.AttachedToParent);
                        accepetChunk.ContinueWith(accept, TaskContinuationOptions.NotOnFaulted | TaskCreationOptions.AttachedToParent);
                        evtConnectionDone.WaitOne();
                    }
                });
            }
            //-------------------------------------------------
            void accept(Task<Socket> accepetChunk)
            {
                state = new StateObject();
                evtConnectionDone.Set();
                state.workSocket = accepetChunk.Result;
                Task<int> readChunk = Task<int>.Factory.FromAsync(
                                                           state.workSocket.BeginReceive,
                                                           state.workSocket.EndReceive,
                                                           state.buffer,
                                                           state.bytesRead,
                                                           state.buffer.Length - state.bytesRead,
                                                           null,
                                                           TaskCreationOptions.AttachedToParent);
                readChunk.ContinueWith(read, TaskContinuationOptions.NotOnFaulted | TaskCreationOptions.AttachedToParent);
            }
            //-------------------------------------------------
            void read(Task<int> readChunk)
            {
                state.bytesRead += readChunk.Result;
                if (readChunk.Result > 0 && state.bytesRead < state.buffer.Length)
                {
                    read();
                    return;
                }
                _data = doTask(_data);
                Task<int> sendChunk = Task<int>.Factory.FromAsync(
                                                           state.workSocket.BeginSend,
                                                           state.workSocket.EndSend,
                                                           state.buffer,
                                                           state.bytesRead,
                                                           state.buffer.Length - state.bytesRead,
                                                           null,
                                                           TaskCreationOptions.AttachedToParent);
                sendChunk.ContinueWith(send, TaskContinuationOptions.NotOnFaulted | TaskCreationOptions.AttachedToParent);
            }
            //-------------------------------------------------
            void send(Task<int> readChunk)
            {
                state.workSocket.Shutdown(SocketShutdown.Both);
                state.workSocket.Close();
            }
            //-------------------------------------------------
            byte[] doTask(byte[] data)
            {
                return Array.Reverse(data);
            }
            //-------------------------------------------------
        }
    }
