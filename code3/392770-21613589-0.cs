            logger.Info("Create Z: drive ");
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @"/C net use z: \\" + Tools.servername + @"\SHARE_NAME_HERE /user:USER_NAME_HERE PASSWORD_HERE";
            process.StartInfo = startInfo;
            process.Start();
            logger.Info("Z: drive created ");
            // wait get Z:
            int xtimestimeout = 5;
            while (!Directory.Exists(@"Z:\") & (xtimestimeout > 0))
            {
                Application.DoEvents();
                SetBalloonTip(@"Program", @"connecting... please wait");
                ShowBalloon();
                logger.Info("Creating Z:... waiting...");
                Application.DoEvents();
                System.Threading.Thread.Sleep(3000);
                xtimestimeout -= 1;
            }
            // check for sucessfull creation of Z: in server Z:\somedirectory
            if (!Directory.Exists(@"Z:\"))
            {
                SendEmail2("Oh my... help!", "drive Z: not created <<< CHECK!");
                logger.Info("Z: email sent because of not created");
            }
            logger.Info("Z: drive created successfully.");
