string registry_key32 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
{
    var subKeys = key.GetSubKeyNames();
}
string registry_key64 = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
{
    var subKeys = key.GetSubKeyNames();
}
