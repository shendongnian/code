    private static void run(string path, MyData myData)
            {
                Process p = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/c \"python ProcessDataGUI.py\"" + " "
                                      + path + " "
                                      + string.Join(" ", myData.TemperatureList.Cast<int>().ToList()) + " "
                                      + string.Join(" ", myData.DataList.Cast<int>().ToList()) + " "
    								  + string.Join(" ", myData.ToggleData.Cast<float>().ToList()) + " "
                                      + toggleEnable + " "
    								  + string.Join(" ", myData.BandEnable.Cast<int>().ToList()) + " "
                                      + string.Join(" ",FrequencyDynamicList); + " " 
    								  + string.Join(" ",FrequencyIndexList);
                p.StartInfo = startInfo;
                p.Start();
            }
