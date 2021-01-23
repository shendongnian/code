    using System;
    using System.IO;
    using System.IO.Pipes;
    using System.Windows.Forms;
    using System.Runtime.Serialization.Formatters.Binary;
    namespace FunWithNamedPipes
    {
        public class PipeListenerMessageReceivedEventArgs<TMessage> : EventArgs
        {
            public PipeListenerMessageReceivedEventArgs(TMessage message)
            {
                this.Message = message;
            }
    
            public TMessage Message { get; private set; }
        }
    
        public delegate void MessageReceivedHandler<TMessage>(Object sender, PipeListenerMessageReceivedEventArgs<TMessage> e);
    
        public class PipeListener<TMessage> : IDisposable
        {
            public event MessageReceivedHandler<TMessage> MessageReceived;
    
            static readonly String PIPENAME = typeof(PipeListener<TMessage>).FullName;
            static readonly BinaryFormatter formatter = new BinaryFormatter();
    
            NamedPipeServerStream pipeServer;
    
            internal void Start()
            {
                if (pipeServer == null) pipeServer = new NamedPipeServerStream(PIPENAME, PipeDirection.In, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
    
                pipeServer.BeginWaitForConnection(new AsyncCallback(PipeConnection), null);
            }
    
            private void PipeConnection(IAsyncResult result)
            {
                pipeServer.EndWaitForConnection(result);
    
                try
                {
                    var message = (TMessage)formatter.Deserialize(pipeServer);
                    this.OnMessageRecieved(new PipeListenerMessageReceivedEventArgs<TMessage>(message));
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
    
                pipeServer.Close();
                pipeServer.Dispose();
                pipeServer = null;
    
                this.Start();
        }
    
            internal void EndPipe()
            {
                pipeServer.Close();
                pipeServer.Dispose();
            }
    
            public static void SendMessage(TMessage message)
            {
                using (var pipeClient = new NamedPipeClientStream(".", PIPENAME, PipeDirection.Out, PipeOptions.None))
                {
                    pipeClient.Connect();
    
                    formatter.Serialize(pipeClient, message);
                    pipeClient.Flush();
    
                    pipeClient.WaitForPipeDrain();
                    pipeClient.Close();
                }
            }
    
            protected virtual void OnMessageRecieved(PipeListenerMessageReceivedEventArgs<TMessage> e)
            {
                if (this.MessageReceived != null)
                {
                    this.MessageReceived(this, e);
                }
            }
    
            void IDisposable.Dispose()
            {
                if(pipeServer != null)
                {
                    try { pipeServer.Dispose(); }
                    catch { }
                }
            }
        }
    }
