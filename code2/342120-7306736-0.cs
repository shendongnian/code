    //i wrote this code, which is working in most of the cases :
    
    //----------------------------------------------------------------------------------------------          
            
                if (uninstallString.Contains("msiexec"))
                    {
                    uninstallString = uninstallString.Replace("\"", "");
                    uninstallString = RegistryHandler.getCommandInCommaAndArgumentsOutside(uninstallString);
                    }
                    else
                    {
                      if (uninstallString.StartsWith(@""""))
                         {
                         int indexOfLastComma = uninstallString.IndexOf("\"", 1) + 1;
                         procStartInfo.FileName = uninstallString.Substring(0, indexOfLastComma);
                         procStartInfo.Arguments = uninstallString.Substrin(indexOfLastComma,uninstallString.Length - indexOfLastComma));
                        
                         }
                         else
                         {
                          procStartInfo.FileName = "cmd.exe";
                          procStartInfo.Arguments = "/c " + RegistryHandler.getCommandInCommaAndArgumentsOutsideByExe(uninstallString); 
                          }     
    }
    
    //----------------------------------------------------------------------------------------------
                
                           
              public static string getCommandInCommaAndArgumentsOutsideByExe(string command)
                     {
                       int ind = 0;
                       string[] prms = command.Split(' ');
                           
                       ind = prms[0].Length; //command.IndexOf(".exe") + 4;
                            
                       int exeLocationIndex = command.IndexOf(".exe") + 4;
                       string cmd = command.Substring(0, exeLocationIndex);
                       string arguments = command.Substring(command.IndexOf(".exe") + 4, command.Length - exeLocationIndex);
                      
                       return "\"" + cmd + "\"" + arguments;
                           }
