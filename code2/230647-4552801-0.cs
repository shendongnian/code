    using System;
    using System.Management;
    using System.Diagnostics;
    class App {
        public static void Main() {
        GetProcessInfo(Process.GetCurrentProcess().Handle. ToInt32());
        }
    
        static void GetProcessInfo(int handle)
        {
            using(ManagementObject proc = new ManagementObject("Win32_Process.Handle='" + handle.ToString() + "'"))
            {
                proc.Get();
                string[] s = new String[2];
                //Invoke the method and populate the array with the user name and domain
                proc.InvokeMethod("GetOwner",(object[])s);
                Console.WriteLine("User: " + s[1]+ "\\" + s[0]);
            }
        }
    }
