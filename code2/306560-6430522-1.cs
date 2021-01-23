    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Management;
    
    namespace ConsoleApplication11
    {
        class Program
        {
    
            private static string DateTimetoUTC(DateTime dateParam)
            {
                string buffer = dateParam.ToString("********HHmmss.ffffff");
                TimeSpan tickOffset = TimeZone.CurrentTimeZone.GetUtcOffset(dateParam);
                buffer += (tickOffset.Ticks >= 0) ? '+' : '-';
                buffer += (Math.Abs(tickOffset.Ticks) / System.TimeSpan.TicksPerMinute).ToString("d3");
                return buffer;
            }
    
            static void Main(string[] args)
            {
                try
                {
                    ConnectionOptions conn = new ConnectionOptions();
                    conn.Username = "theusername";
                    conn.Password = "password";
                    //connectoptions.Authority = "ntlmdomain:";
                    conn.EnablePrivileges = true;
                    ManagementScope scope = new ManagementScope(@"\\192.168.52.128\root\cimv2", conn);
                    scope.Connect();
                    Console.WriteLine("Connected");
    
                    ObjectGetOptions objectGetOptions = new ObjectGetOptions();
                    ManagementPath managementPath = new ManagementPath("Win32_ScheduledJob");
                    ManagementClass classInstance = new ManagementClass(scope, managementPath, objectGetOptions);
    
                    ManagementBaseObject inParams = classInstance.GetMethodParameters("Create");
                    inParams["Command"] = @"notepad.exe";
                    //the itme must be in UTC format
                    string StartTime = DateTimetoUTC(DateTime.Now.AddMinutes(1));
                    Console.WriteLine(StartTime);
                    inParams["StartTime"] = StartTime;
    
                    ManagementBaseObject outParams = classInstance.InvokeMethod("Create", inParams, null);
                    Console.WriteLine("JobId: " + outParams["JobId"]);
                    Console.ReadKey();
                }
                catch(ManagementException err)
                {
                    Console.WriteLine("An error occurred while trying to execute the WMI method: " + err.Message);
                    Console.ReadKey();
                }
            }
        }
    }
