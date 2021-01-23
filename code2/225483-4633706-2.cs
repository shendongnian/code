    public class DomainCheck
    {
        public DomainCheck() { }
        public string VerifyIP(string ipAddress)
        {
            if (String.IsNullOrEmpty(ipAddress))
                return "IP Address is invalid!";
            string r = "";
            if (ipAddress.Contains(","))
            {
                foreach (string ip in ipAddress.Split(','))
                    r += String.Format("<br/><br/>#### <em>Checking {0}</em>{1}", ip, CheckIPAddress(ip));
            }
            else
                r += CheckIPAddress(ipAddress);
            return r;
        }
        public string GetIPFromDomain(string hostname)
        {
            string r = "";
            IPAddress[] addresslist = Dns.GetHostAddresses(hostname);
            foreach (IPAddress theaddress in addresslist)
            {
                r += String.Format("{0},", theaddress.ToString());
            }
            return String.IsNullOrEmpty(r) ? null : r.TrimEnd(',');
        }
        private string CheckIPAddress(string ipAddress)
        {
            string r = "";
            try
            {
                IPAddress hostIPAddress = IPAddress.Parse(ipAddress);
                IPHostEntry hostInfo = Dns.GetHostByAddress(hostIPAddress);
                // Get the IP address list that resolves to the host names contained in  
                // the Alias property. 
                IPAddress[] address = hostInfo.AddressList;
                // Get the alias names of the addresses in the IP address list. 
                String[] alias = hostInfo.Aliases;
                r += String.Format(
                        "<br/>Host name: <br/>- <strong>{0}</strong><br/>Aliases: ",
                        hostInfo.HostName);
                if (alias.Length == 0)
                    r += "<br/><em>none</em>";
                else
                    for (int index = 0; index < alias.Length; index++)
                        r += String.Format("<br/>- <strong>{0}</strong>", alias[index]);
                r += "<br/>IP address list: ";
                if (address.Length == 0)
                    r += "<br/><em>none</em>";
                else
                    for (int index = 0; index < address.Length; index++)
                        r += String.Format("<br/>- <strong>{0}</strong>", address[index]);
            }
            catch (SocketException e)
            {
                r = String.Format(
                        "SocketException caught!!!<br/>Source : {0}<br/>Message : {1}",
                        e.Source, e.Message);
            }
            catch (FormatException e)
            {
                r = String.Format(
                        "FormatException caught!!!<br/>Source : {0}<br/>Message : {1}",
                        e.Source, e.Message);
            }
            catch (ArgumentNullException e)
            {
                r = String.Format(
                        "ArgumentNullException caught!!!<br/>Source : {0}<br/>Message : {1}",
                        e.Source, e.Message);
            }
            catch (Exception e)
            {
                r = String.Format(
                        "Exception caught!!!<br/>Source : {0}<br/>Message : {1}",
                        e.Source, e.Message);
            }
            return r;
        }
    }
