    public void mciConvertWavMP3(string fileName, bool waitFlag)
    {
        //maxLen is in ms (1000 = 1 second)
        string outfile= "-b 32 --resample 22.05 -m m \"" + pworkingDir+fileName + "\" \"" + pworkingDir + fileName.Replace(".wav",".mp3") + "\"";
        System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
        psi.FileName = "\"" + pworkingDir + "lame.exe" + "\"";
        psi.Arguments = outfile;
        //psi.WorkingDirectory = pworkingDir;
        psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
        System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);
    
        if (waitFlag)
        {
            p.WaitForExit();
            // wait for exit of called application
        }
    }
