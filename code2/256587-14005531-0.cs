    /// <summary>
    /// Close the shelled process, if there is any
    /// </summary>
    /// <param name="reason">why closing?</param>
    public static void shellTerminate(string reason)
    {
        Process p = shelledProcess;
        try
        {
            if (p == null)
            {
                o3(reason + ". No shelled process.");
            }
            else if (p.HasExited)
            {
                o3(reason + ". Process has exited already.");
            }
            else
            {
                //Process is still running.
                //Test to see if the process is hung up.
                if (p.Responding)
                {
                    //Process was responding; close the main window.
                    o3(reason + ". Process is being closed gracefully.");
                    if (p.CloseMainWindow())
                    {
                        //Process was not responding; force the process to close.
                        o3(reason + ". Process is being killed.");
                        p.Kill();
                        p.Close();
                        p = null;
                    }
                }
                if (p != null)
                {
                    //Process was not responding; force the process to close.
                    o3(reason + ". Process is being killed.");
                    p.Kill();
                }
                p.Close();
            }
            if (shellOut != null)
            {
                shellOut.Close();
                shellOut = null;
            }
            shelledProcess = null;
        }
        catch (Exception ex)
        {
            o("Exception in shellTerminate: " + ex.Message);
        }
    }
