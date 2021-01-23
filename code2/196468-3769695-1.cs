    using System;
    using System.IO;
    using System.Management;
    using System.Diagnostics;
    
    
    namespace Monitor
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                double Free, Size, FreePercentage;
                DateTime Now = DateTime.Now;
    
                string scopeStr = string.Format(@"root\cimv2", "TestSqlServer");
    
    
                ManagementScope scope = new ManagementScope(scopeStr);
                scope.Connect();
    
                string queryString = "SELECT * FROM Win32_Volume WHERE DriveLetter IS NULL";
                SelectQuery query = new SelectQuery(queryString);
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
                {
                    Console.WriteLine("Entering Volume loop: ");
                    foreach (ManagementObject disk in searcher.Get())
                    {
                        Console.WriteLine("foreach Volume: ");
                        //-------------------------------------------------------------------------
                        //Console.WriteLine("Free %" + double.Parse(disk["FreeSpace"].ToString()) / double.Parse(disk["Capacity"].ToString()) * 100);
                        FreePercentage = double.Parse(disk["FreeSpace"].ToString()) / double.Parse(disk["Capacity"].ToString()) * 100;
                        //-------------------------------------------------------------------------
                        string _MountPoint = disk["Name"].ToString();
                        //Console.WriteLine("Free: " + disk["FreeSpace"].ToString());
                        Free = Math.Round(Convert.ToDouble(disk["FreeSpace"]) / (1024 * 1024), 2);
                        Console.WriteLine("Free: " + Free + " MB");
                        //Console.WriteLine("Capacity: " + disk["Capacity"].ToString());
                        Size = Math.Round(Convert.ToDouble(disk["Capacity"]) / (1024 * 1024), 2);
                        Console.WriteLine("Size: " + Size + " MB");
                        if (_MountPoint[_MountPoint.Length - 1] == Path.DirectorySeparatorChar)
                        {
                            _MountPoint = _MountPoint.Remove(_MountPoint.Length - 1);
                        }
                        _MountPoint = _MountPoint.Replace("\\", "\\\\\\\\");
    
                        string _MountPointQueryString = "select * FROM Win32_MountPoint WHERE Directory=\"Win32_Directory.Name=\\\"" + _MountPoint + "\\\"\"";
    
                        SelectQuery _MountPointQuery = new SelectQuery(_MountPointQueryString);
                        using (
                            ManagementObjectSearcher mpsearcher =
                                new ManagementObjectSearcher(scope, _MountPointQuery))
                        {
                            Console.WriteLine("Entering directory Foreach loop: ");
                            foreach (ManagementObject mp in mpsearcher.Get())
                            {
                                Console.WriteLine("Foreach directory: ");
    
                                try
                                {
                                    //Console.WriteLine("Volume: " + mp["Volume"].ToString());
                                    Console.WriteLine("Directory: " + mp["Directory"].ToString());
                                    string Volume = mp["Directory"].ToString().Replace("Win32_Directory.Name=", "");
    
    
                                    if (FreePercentage <= 5.00)
                                    {
                                        throw new Exception("\nLabel: " + Volume + "\nSeverity: " + EventLogEntryType.Error + "\nTime: " + Now + "\nMessage: disk space threshhold: " + CalculateUsedSpace(Free, Size) + " % used (" + Free + "MB" + " free)");
                                    }
    
                                }
                                catch (Exception ex)
                                {
                                    EventLog.WriteEntry("DriveStats Warning", "Message: " + ex.Message, EventLogEntryType.Error);
                                }
                            }
                        }
                    }
                }
    
    
            }
    
            static double CalculateUsedSpace(double f, double s)
            {
                double UsedPercentage;
                if (s == 0)
                {
                    return f;
                }
                else if (s >= 0 && f == 0)
                {
                    UsedPercentage = 100.00;
                    return UsedPercentage;
                }
                else
                {
                    double UsedSpace = s - f;
                    UsedPercentage = (UsedSpace / s) * 100;
                    UsedPercentage = Math.Round(UsedPercentage, 2);
                    //Console.WriteLine("Used Percentage: " + UsedPercentage);
                    return Math.Round(UsedPercentage, 2);
                }
            }
    
            static double CalculateFreePercentage(double f, double s)
            {
                double FreePercentage;
                if (f == 0)
                {
                    FreePercentage = 0;
                    return FreePercentage;
                }
                else
                {
                    FreePercentage = (f / s) * 100;
                    //Console.WriteLine("Free Percentage: " + FreePercentage);
                    return Math.Round(FreePercentage, 2);
                }
    
            }
        }
    }
