        public static bool LinuxOS
        {
            get { return Path.DirectorySeparatorChar == '/'; }
        }
        public static void SendKeys(String output)
        {
            if (LinuxOS)
            {
                var args = "";
                switch (output)
                {
                    case "{RIGHT}":
                        args = "key Right";
                        break;
                    case "{LEFT}":
                        args = "key Left";
                        break;
                    default:
                        if (output.StartsWith("{") && output.EndsWith("}"))
                            output = output.Substring(1, output.Length - 2);
                         
                        args = "type \"" + output + "\"";
                        break;
                }
                var proc = new Process
                           {
                                   StartInfo =
                                   {
                                           FileName = "xdotool",
                                           Arguments = args,
                                           UseShellExecute = false,
                                           RedirectStandardError = false,
                                           RedirectStandardInput = false,
                                           RedirectStandardOutput = false
                                   }
                           };
                proc.Start();
            }
            else
            {
                System.Windows.Forms.SendKeys.Send(output);
            }
        }
