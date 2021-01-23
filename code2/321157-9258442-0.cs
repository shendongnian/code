    using System;
    using System.Windows.Forms;
    using System.IO.Ports;
    using System.Threading;
    using System.IO;
    using System.Text;
    public class clsState {
        private const int BUFFER_SIZE = 1024;
        public byte[] BytesBuffer = new byte[BUFFER_SIZE];
        public SerialPort sp;
        public Stream stream;
    }
    public partial class Form1 : Form {
 
        SerialPort sp;
        Stream stream;
        IAsyncResult recv_result;
        bool endLoop = false;
        Thread _readThread;
        private ManualResetEvent _readDone = new ManualResetEvent(false);
        private void button1_Click(object sender, EventArgs e) {
            sp = new SerialPort("COM8", 9600);
            sp.Open();
            sp.ReadTimeout = 50000;
            sp.NewLine = "\n\r\0";
            stream = sp.BaseStream;
            // save serial port and stream to state object
            clsState state =  new clsState();
            state.sp = sp;
            state.stream = stream;
            // create worker thread
            endLoop = false;
            _readThread = new Thread(() => ReadThreadProc(state))
            _readThread.IsBackground = true;
            _readThread.Start();
        }
        private void ReadThreadProc(clsState state) {
            while (endLoop == false){
                // open and then close the gate as soon as after one thread passed
                _readDone.Reset();
                // starting ascynchronous read 
                recv_result = state.stream.BeginRead(state.BytesBuffer, 0, state.BytesBuffer.Length, new AsyncCallback(ReadCallBack), state.stream);
                
                // worker thread block in here (waiting for... _readDone.Set())
                _readDone.WaitOne();
            }
        }
        private void ReadCallBack(IAsyncResult ar) {   
            string temp;
            int bytesRead = 0;
            // read serial port and stream from IAsyncResult
            clsState state = (clsState) ar.AsyncState;
            // if port serial is open and..
            if (state.sp.IsOpen) {
                // the stream can read then..
                if(state.stream.CanRead) {
                    // wait for asynchronous read to completed
                    bytesRead = state.stream.EndRead(ar);
                }
            }
            if(bytesRead > 0) {
               // convert data in state.BytesBuffer from bytes array to string and save to temp variable
               temp = Encoding.ASCII.GetString(state.BytesBuffer);
                // open gate for next data
               _readDone.Set();
            }
        }
 
        private void disconnectButton_Click(object sender, EventArgs e) {
            // ending loop and will kill worker thread...
            endLoop = true;
            // release begin read
            _readDone.Set();      
            if (_readThread != null){
                if (_readThread.IsAlive){ // if worker thread still live
                    _readThread.Join();   // wait thread off in here..
                }
            }
            // close serial port
            if (sp.IsOpen) sp.Close();
            // close stream and dispose it 
            if (stream.CanRead || stream.CanWrite) {
                stream.Close();
                stream.Dispose();
            }
        }
    }
