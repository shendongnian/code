csharp
bool checkIfJavaInstalled()
{
    string JavaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment\\";
    bool installed = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(JavaKey) == null;
    return installed;
}
New code:
csharp
bool checkIfJavaInstalled()
{
    var regview = Microsoft.Win32.RegistryView.Registry64;
    if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432")))
    {
        regview = Microsoft.Win32.RegistryView.Registry32;
    }
    string JavaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment\\";
    bool installed = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, regview).OpenSubKey(JavaKey) != null;
    return installed;
}
