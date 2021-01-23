    internal static bool DeleteZoneFromDns(string ZoneName)
        {
            try
            {
                string Query = "SELECT * FROM MicrosoftDNS_Zone WHERE ContainerName = '" + ZoneName + "'";
                ObjectQuery qry = new ObjectQuery(Query);
                DnsProvider dns = new DnsProvider();
                ManagementObjectSearcher s = new ManagementObjectSearcher(dns.Session, qry);
                ManagementObjectCollection col = s.Get();
                dns.Dispose();
                foreach (ManagementObject obj in col)
                {
                    obj.Delete();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
