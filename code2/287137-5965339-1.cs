     var safeToRun = true;
     var os = Environment.OSVersion;
     if (os.Version.Major > 5) {//Got Vista or Win7
         if (!IsElevated) {
             var message = new StringBuilder();
             message.AppendLine("You are running Vista or Win7 and this program ");
             message.AppendLine("needs to run with Admin Privileges. When the ");
             message.AppendLine("program closes please right click on the executable");
             message.AppendLine("or icon and select 'Run As Administrator'.");
             message.AppendLine("");
             message.AppendLine("The Program will now close.");
             MessageBox.Show(message.ToString(), "Insufficient Privileges", MessageBoxButtons.OK, MessageBoxIcon.Error);
             safeToRun = false;
         }
     }
    
     if (safeToRun) {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MainForm());
     }
