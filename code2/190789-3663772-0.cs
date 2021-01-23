       private ManagementScope _session = null;
       public ManagementPath CreateCNameRecord(string DnsServerName, string ContainerName, string OwnerName, string PrimaryName)
        {
            _session = new ManagementScope("\\\\" + DnsServerName+ "\\root\\MicrosoftDNS", con);
            _session.Connect();
            ManagementClass zoneObj = new ManagementClass(_session, new ManagementPath("MicrosoftDNS_CNAMEType"), null);
            ManagementBaseObject inParams = zoneObj.GetMethodParameters("CreateInstanceFromPropertyData");
            inParams["DnsServerName"] = ((System.String)(DnsServerName));
            inParams["ContainerName"] = ((System.String)(ContainerName));
            inParams["OwnerName"] = ((System.String)(OwnerName));
            inParams["PrimaryName"] = ((System.String)(PrimaryName));
            ManagementBaseObject outParams = zoneObj.InvokeMethod("CreateInstanceFromPropertyData", inParams, null);
            if ((outParams.Properties["RR"] != null))
            {
                return new ManagementPath(outParams["RR"].ToString());
            }
            return null;
        }
