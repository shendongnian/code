    StringBuilder sb = new StringBuilder();
    
    sb.WriteLine("Network adapter: {0}", adapters[i].Name);
    sb.WriteLine("    Status:            {0}", adapters[i].OperationalStatus.ToString());
    sb.WriteLine("    Interface:         {0}", adapters[i].NetworkInterfaceType.ToString());
    sb.WriteLine("    Description:       {0}", adapters[i].Description);
    sb.WriteLine("    ID:                {0}", adapters[i].Id);
    sb.WriteLine("    Speed:             {0}", adapters[i].Speed);
    sb.WriteLine("    SupportsMulticast: {0}", adapters[i].SupportsMulticast);
    sb.WriteLine("    IsReceiveOnly:     {0}", adapters[i].IsReceiveOnly);
    sb.WriteLine("    MAC:               {0}", adapters[i].GetPhysicalAddress().ToString());
    
    textBox1.Text = sb.ToString();
