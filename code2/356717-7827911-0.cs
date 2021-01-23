            using (ZipFile zip = new ZipFile())
            {
                // add this map file into the "images" directory in the zip archive
                zip.AddFile("test.xlsx");
                zip.Save("MyZipFile.zip");
                var accessControl = File.GetAccessControl("MyZipFile.zip");
                
                var fileSystemAccessRule = new FileSystemAccessRule(
                                            @"BUILTIN\IIS_IUSRS",
                                            FileSystemRights.Read | FileSystemRights.ReadAndExecute,
                                            AccessControlType.Allow);
                var fileSystemAccessRule2 = new FileSystemAccessRule(
                                            @"IIS AppPool\DefaultAppPool",
                                            FileSystemRights.Read | FileSystemRights.ReadAndExecute,
                                            AccessControlType.Allow);
                accessControl.AddAccessRule(fileSystemAccessRule);
                accessControl.AddAccessRule(fileSystemAccessRule2);
                File.SetAccessControl(path, accessControl);
            }
