    StringBuilder sb = new StringBuilder();
    
    sb.AppendLine(string.Format("Network adapter: {0}", adapters[i].Name));
    sb.AppendLine(string.Format("    Status:            {0}", adapters[i].OperationalStatus.ToString()));
    sb.AppendLine(string.Format("    Interface:         {0}", adapters[i].NetworkInterfaceType.ToString()));
    sb.AppendLine(string.Format("    Description:       {0}", adapters[i].Description));
    sb.AppendLine(string.Format("    ID:                {0}", adapters[i].Id));
    sb.AppendLine(string.Format("    Speed:             {0}", adapters[i].Speed));
    sb.AppendLine(string.Format("    SupportsMulticast: {0}", adapters[i].SupportsMulticast));
    sb.AppendLine(string.Format("    IsReceiveOnly:     {0}", adapters[i].IsReceiveOnly));
    sb.AppendLine(string.Format("    MAC:               {0}", adapters[i].GetPhysicalAddress().ToString()));
    
    textBox1.Text = sb.ToString();
