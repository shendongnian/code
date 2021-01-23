    System.ServiceProcess.ServiceController controller = new   System.ServiceProcess.ServiceController("Spooler");
                    controller.Stop();
                    System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(@"C:\Windows\System32\spool\PRINTERS");
    
                    var files = info.GetFiles();
    
                    foreach (var file in files)
                    {
                        file.Delete();
                    }
                    controller.Start();
