    using System;
    using System.IO;
    using System.Security;
    using System.Text.RegularExpressions;
    
    namespace YourNameSpace
    {
        public class SystemInfo
        {
            private const string FRAMEWORK_PATH = "\\Microsoft.NET\\Framework";
            private const string WINDIR1 = "windir";
            private const string WINDIR2 = "SystemRoot";
    
            public static string FrameworkVersion
            {
                get
                {
                    try
                    {
                        return getHighestVersion(NetFrameworkInstallationPath);
                    }
                    catch (SecurityException)
                    {
                        return "Unknown";
                    }
                }
            }
    
            private static string getHighestVersion(string installationPath)
            {
                string[] versions = Directory.GetDirectories(installationPath, "v*");
                string version = "Unknown";
    
                for (int i = versions.Length - 1; i >= 0; i--)
                {
                    version = extractVersion(versions[i]);
                    if (isNumber(version))
                        return version;
                }
    
                return version;
            }
    
            private static string extractVersion(string directory)
            {
                int startIndex = directory.LastIndexOf("\\") + 2;
                return directory.Substring(startIndex, directory.Length - startIndex);
            }
    
            private static bool isNumber(string str)
            {
                return new Regex(@"^[0-9]+\.?[0-9]*$").IsMatch(str);
            }
    
            public static string NetFrameworkInstallationPath
            {
                get { return WindowsPath + FRAMEWORK_PATH; }
            }
    
            public static string WindowsPath
            {
                get
                {
                    string winDir = Environment.GetEnvironmentVariable(WINDIR1);
                    if (String.IsNullOrEmpty(winDir))
                        winDir = Environment.GetEnvironmentVariable(WINDIR2);
    
                    return winDir;
                }
            }
        }
    }
