                Process Replactions = new Process();
                ProcessStartInfo procInfo = new ProcessStartInfo();
                procInfo.UseShellExecute = false;
                procInfo.FileName = HttpContext.Current.Server.MapPath("~/Rep.bat");
                procInfo.WorkingDirectory = @""; //The working DIR.
                Securepass();
                procInfo.Verb = "runasuser";
                procInfo.Domain = "yourDomian.de";
                procInfo.UserName = "Username";
                procInfo.Password = sSPasswordFianl;
                procInfo.CreateNoWindow = true;
                Process.Start(procInfo);  //Start that process.
                 string output;
                return (output="OK");
            }
            catch (Exception ex)
            {
                return (ex.Message.ToString());
            }`
