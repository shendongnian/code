    public class TestSerialPort : ISerialPort
    {
        public string Buffer;
        public int SendCount;
        public void Send(char c)
        {
            SendCount++;
            Buffer += c;
            Echo.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler Echo;
    }
