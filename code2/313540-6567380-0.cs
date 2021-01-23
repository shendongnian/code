        ///
    /// Author : Muhammed Rauf K
    /// Date : 03/07/2011
    /// A Simple console application to create and display registry sub keys
    ///
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    // it's required for reading/writing into the registry:
    using Microsoft.Win32;
    
    
    namespace InstallationInfoConsole
    {
    class Program
    {
    static void Main(string[] args)
    {
    
    Console.WriteLine("Registry Information ver 1.0");
    Console.WriteLine("----------------------------");
    
    Console.Write("Input application name to get the version info. (for example 'Nokia PC Suite'): ");
    string nameToSearch = Console.ReadLine();
    
    GetVersion(nameToSearch);
    
    Console.WriteLine("----------------------------");
    
    Console.ReadKey();
    
    
    }
    
    ///
    /// Author : Muhammed Rauf K
    /// Date : 03/07/2011
    /// Create registry items
    ///
    static void Create()
    {
    try
    {
    Console.WriteLine("Creating registry...");
    // Create a subkey named Test9999 under HKEY_CURRENT_USER.
    string subKey;
    Console.Write("Input registry sub key :");
    subKey = Console.ReadLine();
    RegistryKey testKey = Registry.CurrentUser.CreateSubKey(subKey);
    Console.WriteLine("Created sub key {0}", subKey);
    Console.WriteLine();
    
    // Create two subkeys under HKEY_CURRENT_USER\Test9999. The
    // keys are disposed when execution exits the using statement.
    Console.Write("Input registry sub key 1:");
    subKey = Console.ReadLine();
    using (RegistryKey testKey1 = testKey.CreateSubKey(subKey))
    {
    testKey1.SetValue("name", "Justin");
    }
    }
    catch (Exception e)
    {
    Console.WriteLine(e.Message);
    }
    }
    static void GetVersion(string nameToSearch)
    {
    // Get HKEY_LOCAL_MACHINE
    RegistryKey baseRegistryKey = Registry.LocalMachine;
    
    // If 32-bit OS
    string subKey
    //= "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
    // If 64-bit OS
    = "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
    RegistryKey unistallKey = baseRegistryKey.OpenSubKey(subKey);
    
    string[] allApplications = unistallKey.GetSubKeyNames();
    foreach (string s in allApplications)
    {
    RegistryKey appKey = baseRegistryKey.OpenSubKey(subKey + "\\" + s);
    string appName = (string)appKey.GetValue("DisplayName");
    if(appName==nameToSearch)
    {
    string appVersion = (string)appKey.GetValue("DisplayVersion");
    Console.WriteLine("Name:{0}, Version{1}", appName, appVersion);
    break;
    }
    
    
    }
    
    }
    
    static void ListAll()
    {
    // Get HKEY_LOCAL_MACHINE
    RegistryKey baseRegistryKey = Registry.LocalMachine;
    
    // If 32-bit OS
    string subKey
    //= "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
    // If 64-bit OS
    = "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
    RegistryKey unistallKey = baseRegistryKey.OpenSubKey(subKey);
    
    string[] allApplications = unistallKey.GetSubKeyNames();
    foreach (string s in allApplications)
    {
    RegistryKey appKey = baseRegistryKey.OpenSubKey(subKey + "\\" + s);
    string appName = (string)appKey.GetValue("DisplayName");
    string appVersion = (string)appKey.GetValue("DisplayVersion");
    Console.WriteLine("Name:{0}, Version{1}", appName, appVersion);
    
    }
    
    }
    }
    } 
