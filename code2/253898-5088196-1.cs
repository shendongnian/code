    public string GetNetworkAdapterName(int Ordinal)
        {
                int i = 1;
                foreach (ManagementObject queryObj in name.Get())
                {
                    bool physicaladapter = Convert.ToBoolean(queryObj["PhysicalAdapter"]);
                    if (physicaladapter == true && i++ == Ordinal)
                    {
                        return Convert.ToString(queryObj["Name"]);
                    }
                }
                return null;
        }
