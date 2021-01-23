using System.Net.NetworkInformation;
using System.Net;
        /// <summary>
        /// Return true if the IP address is valid.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool TestIpAddress (string address)
        {
            PingReply reply;
            Ping pingSender = new Ping ();
            try
            {
                reply = pingSender.Send (address);
            }
            catch (Exception)
            {
                return false;
            }
            return reply.Status == IPStatus.Success;
        }
