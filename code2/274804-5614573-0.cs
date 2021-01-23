                        Process[] processes = Process.GetProcessesByName("OUTLOOK");
                        foreach (Process p in processes)
                        {
                            if (p.MainWindowTitle == mail.GetInspector.Caption)
                            {
                                handle = p.MainWindowHandle;
                                break;
                            }
                        }
