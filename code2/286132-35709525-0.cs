                var query = new ManagementPath(string.Format("Win32_Service.Name='{0}'", serviceName));
                using (ManagementObject service = new ManagementObject(query))
                {
                    object[] wmiParams = new object[10];
                    wmiParams[5] = false;
                    wmiParams[6] = serviceUserName;
                    wmiParams[7] = password;
                    //update credentials for the service
                    var rtn = service.InvokeMethod("Change", wmiParams);
