lang-cs
public static void PinToTaskBar(string filePath)
{
    if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);
    
    var valueData = Registry.LocalMachine.OpenSubKey(
        @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Windows.taskbarpin");
    var key2 = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Classes\*", true);
    var key3 = key2.CreateSubKey("shell", true);
    var key4 = key3.CreateSubKey("{:}", true);
    key4.SetValue("ExplorerCommandHandler", valueData.GetValue("ExplorerCommandHandler"));
    var path = Path.GetDirectoryName(filePath);
    var fileName = Path.GetFileName(filePath);
    // create the shell application object
    dynamic shellApplication = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"));
    var directory = shellApplication.NameSpace(path);
    var item = directory.ParseName(fileName);
    item.InvokeVerb("{:}");
    key3.DeleteSubKey("{:}");
    if (key3.SubKeyCount == 0 && key3.ValueCount == 0)
    {
        key2.DeleteSubKey("shell");
    }
}
See [Pin program to taskbar using PS in Windows 10](https://stackoverflow.com/a/49697230/991578)
