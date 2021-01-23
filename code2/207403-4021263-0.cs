    C#-Code:
        using (ps = PowerShell.Create())
        {
             int a = testSkripte.Count;
             for (int i = 0; i < a; i++)
             {                        
                ps.Runspace.SessionStateProxy.SetVariable("portalpfad", pathExecuteScript);
                ps.Runspace.SessionStateProxy.SetVariable("ScriptLog", (Action<Level, string>)ScriptLog);
       //add following row:
       ps.Runspace.SessionStateProxy.SetVariable("DebugPreference", "Continue");
            ps.AddCommand(System.IO.Path.Combine(pathScripts, testSkripte[i].ToString()));
            ps.Streams.Debug.DataAdded += new EventHandler<DataAddedEventArgs>(Debug_DataAdded);
            ps.Streams.Warning.DataAdded += new EventHandler<DataAddedEventArgs>(Warning_DataAdded);
            ps.Streams.Error.DataAdded += new EventHandler<DataAddedEventArgs>(Error_DataAdded);   
            ps.Invoke();                        
         }
