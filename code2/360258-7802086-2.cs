                String fileName = "myexe.exe";
                    
                String dir = Path.GetDirectoryName(fileName);
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = fileName;
                process.StartInfo.WorkingDirectory = dir;
                process.Start();
                    
                // Wait for process to be created and enter idle condition
                Thread.Sleep(5000);
                IntPtr appWin = FindWindowInProcess(process, s => s.StartsWith("Built on"));
                // Put it into this form
		        SetParent(appWin, this.Handle);
		        // Remove border and whatnot
		        SetWindowLong(appWin, GWL_STYLE, WS_VISIBLE);
		        // Move the window to overlay it on this window
		        MoveWindow(appWin, 0, 0, this.Width, this.Height, true);
