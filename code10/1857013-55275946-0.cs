       private void  GetLoggedPCInfo()
        {
            //string ip = Request.UserHostName;
            //IPAddress myIP = IPAddress.Parse(ip);
            //IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
            //List<string> compName = GetIPHost.HostName.ToString().Split('.').ToList();
            //Session["LoginPC_Name"] = compName.First().ToUpper();
            string dateTime =  DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt");
            Session["LoginDateTime"] = dateTime.ToString();
        }
