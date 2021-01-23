          // The port from 4.0's task that allows hardlinking
            bool hardlinkSucceeded = false;
            if (UseHardlinksIfPossible)
            {
                if (File.Exists(destinationFile))
                {
                    FileUtilities.DeleteNoThrow(destinationFile);
                }
                if (!TwNativeMethods.CreateHardLink(destinationFile, sourceFile, IntPtr.Zero))
                {
                    var win32Exception = new Win32Exception(Marshal.GetLastWin32Error());
                    Log.LogMessage(MessageImportance.High, "Hardlinking had a problem {0}, will retry copying. {1}", new object[] {win32Exception.Message, win32Exception});
                }
                hardlinkSucceeded = true;
            }
            if (!hardlinkSucceeded)
            {
                Log.LogMessageFromResources(MessageImportance.Normal, "Copy.FileComment", new object[] { sourceFile, destinationFile });
                Log.LogMessageFromResources(MessageImportance.Low, "Shared.ExecCommand", new object[0]);
                Log.LogCommandLine(MessageImportance.Low, "copy /y \"" + sourceFile + "\" \"" + destinationFile + "\"");
                File.Copy(sourceFile, destinationFile, true);
            }
            // end port
