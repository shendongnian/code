    public void HandlePresentation(string fullFilePath, bool viewOnScreen, bool autoPrint)
    {
               ProcessStartInfo info = new ProcessStartInfo(fullFilePath);
                if (autoPrint)
                {
                    info.Verb = "Print";
                    info.WindowStyle = ProcessWindowStyle.Hidden; // not normally required
                    Process.Start(info);
                    info.Verb = string.Empty;
                }
    
                if (viewOnScreen)
                {
                    info.WindowStyle = ProcessWindowStyle.Normal;
                    Process.Start(info);
                }
    }
