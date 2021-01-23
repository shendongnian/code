    public class TelnetFactory
    {
        public Telnet Create(string ipAddress, string portNumber)
        {
            return new Telnet(ipAddress, portNumber);
        }
    }
