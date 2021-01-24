        private string GetUserIP()
        {
            string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ipList))
            {
                var ips= ipList.Split(',');
                return ips[ips.Length - 1];
            }
            return Request.ServerVariables["REMOTE_ADDR"];
        }
    
