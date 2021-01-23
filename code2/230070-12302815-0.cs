     String sIP;
     StringBuilder sb = new StringBuilder();
     List<String> lstOctets= new List<string>{ usrIP1.Text, usrIP2.Text, usrIP3.Text, usrIP4.Text };
     foreach (String Octet in lstOctets.GetRange(0,lstOctets.Count - 1))
     {
        sb.Append(string.Format("{0:d}.", Octet));
     }
     if (lstOctets.Count == 4)
        sb.Append(string.Format("{0:d}", lstOctets[lstOctets.Count - 1]));
     else
         sb.Append(string.Format("{0:d}.0", lstOctets[lstOctets.Count - 1]));
     sIP = sb.ToString();
 
