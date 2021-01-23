    public class TelnetFactory
    {
        public Telnet Create(string ipAddress, string portNumber)
        {
            return new Telnet(ipAddress, portNumber);
        }
    }
    // ...
    public class MainForm : Form
    {
        private TelnetFactory telnetFactory;
        private Telnet telnet;
        public MainForm(TelnetFactory telnetFactory)
        {
            this.telnetFactory = telnetFactory;
        }
        // Called by a UI action of some sort...
        private void Connect(string ipAddress, string portNumber)
        {
            if(this.telnet != null)
            {
                this.telnet = telnetFactory.Create(ipAddress, portNumber);
            }
        }
        // Todo: Use telnet in other methods
        // Todo: Just pass the existing telnet instance to SubForm
    }
