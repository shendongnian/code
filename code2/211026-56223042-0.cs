        public static string GetSerial()
        {
            try
            {
                var mc = new ManagementClass("Win32_DiskDrive");
                var moc = mc.GetInstances();
                var res = string.Empty;
                var resList = new List<string>(moc.Count);
                foreach (ManagementObject mo in moc)
                {
                    try
                    {
                        if (mo["InterfaceType"].ToString().Replace(" ", string.Empty) == "USB")
                        {
                            continue;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        res = mo["SerialNumber"].ToString().Replace(" ", string.Empty);
                        resList.Add(res);
                        if (mo["DeviceID"].ToString().Replace(" ", string.Empty).Contains("0"))
                        {
                            if (!string.IsNullOrWhiteSpace(res))
                            {
                                return res;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                res = resList[0];
                if (!string.IsNullOrWhiteSpace(res))
                {
                    return res;
                }
            }
            catch
            {
            }
            return string.Empty;
        }
