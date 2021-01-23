            System.Management.ConnectionOptions connOptions =
                new System.Management.ConnectionOptions();
            connOptions.Impersonation = System.Management.ImpersonationLevel.Impersonate;
            connOptions.EnablePrivileges = true;
            string compName = "RemoteComputerName";
            System.Management.ManagementScope manScope =
                new System.Management.ManagementScope(
                    String.Format(@"\\{0}\ROOT\CIMV2", compName), connOptions);
            manScope.Connect();
            System.Management.ObjectGetOptions objectGetOptions =
                new System.Management.ObjectGetOptions();
            System.Management.ManagementPath managementPath =
                new System.Management.ManagementPath("Win32_Process");
            System.Management.ManagementClass processClass =
                new System.Management.ManagementClass(manScope, managementPath, objectGetOptions);
            System.Management.ManagementBaseObject inParams =
                processClass.GetMethodParameters("Create");
            inParams["CommandLine"] = @"c:\MyBatchFile.bat";
            System.Management.ManagementBaseObject outParams =
                processClass.InvokeMethod("Create", inParams, null);
