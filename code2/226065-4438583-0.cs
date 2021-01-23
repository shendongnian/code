    public static bool CheckIfIpValid(string allowedStartIp, string allowedEndIp, string ip)
            {
                // if both start and end ip's are null, every user with these credential can log in, no ip restriction needed.
            if (string.IsNullOrEmpty(allowedStartIp) && string.IsNullOrEmpty(allowedEndIp))
                return true;
            bool isStartNull = string.IsNullOrEmpty(allowedStartIp),
                isEndNull = string.IsNullOrEmpty(allowedEndIp);
            string[] startIpBlocks, endIpBlocks, userIp = ip.Split('.');
            if (!string.IsNullOrEmpty(allowedStartIp))
                startIpBlocks = allowedStartIp.Split('.');
            else
                startIpBlocks = "0.0.0.0".Split('.');
            if (!string.IsNullOrEmpty(allowedEndIp))
                endIpBlocks = allowedEndIp.Split('.');
            else
                endIpBlocks = "999.999.999.999".Split('.');
            for (int i = 0; i < userIp.Length; i++)
            {
                // if current block is smaller than allowed minimum, ip is not valid.
                if (Convert.ToInt32(userIp[i]) < Convert.ToInt32(startIpBlocks[i]))
                    return false;
                // if current block is greater than allowed maximum, ip is not valid.
                else if (Convert.ToInt32(userIp[i]) > Convert.ToInt32(endIpBlocks[i]))
                    return false;
                // if current block is greater than allowed minimum, ip is valid.
                else if ((Convert.ToInt32(userIp[i]) > Convert.ToInt32(startIpBlocks[i])) && !isStartNull)
                    return true;
                
            }
            return true;
        }
