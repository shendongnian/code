using System.Net.NetworkInformation;
using System.Net;
        /// <summary>
        /// Return true if the IP address is valid.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool TestIpAddress (string address)
        {
            string[] parts = address.Split('.');
            byte[] byteAddress = new byte[4];
            int intOut;
            if (parts.Length < 4)
                return false;
            for (int i = 0;   i < 4;   ++i)
                if (!int.TryParse (parts [i], out intOut))
                    return false;
                else
                    byteAddress [i] = (byte) intOut;
            Ping pingSender = new Ping ();
            IPAddress ipAddress = new IPAddress (byteAddress);
            PingReply reply = pingSender.Send (address);
            return reply.Status == IPStatus.Success;
        }
