    public string GetNetworkAdapterName(int index)
    {
        ManagementObject[] queryObjects = name.Get();
        if(index > queryObjects.Length)
            return String.Empty;
        ManagementObject queryObj = queryObjects[index];
        if(Convert.ToBoolean(queryObj["PhysicalAdapter"]))
            return queryObj["Name"].toString();
        else
            return String.Empty;      
    }
