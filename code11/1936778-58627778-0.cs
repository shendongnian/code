public Form1()
{
    InitializeComponent();
    foldersToCopyFrom = Directory.GetFiles(@"C:\temp\tempVideo\Storm.mp4\", "*.*", SearchOption.AllDirectories).ToList();
}
To copy them to the `folderToCopy`, you would need to use [File.Copy][2], e.g.
public void CopyTo(string[] files, string directory, bool overwriteIfExists)
{
    if (files == null)
    {
        throw new ArgumentNullException("files");
    }
    else if (!Directory.Exists(directory))
    {
        //throw Exception;
        Directory.CreateDirectory(directory);
    }
    int length = files.Length;
    for (int i = 0; i < length; i++)
    {
        File.Copy(files[i], directory, overwriteIfExists);
    }
}
So your full code would be something like:
public Form1()
{
    InitializeComponent();
    CopyTo(Directory.GetFiles(@"C:\temp\tempVideo\Storm.mp4\", "*.*", SearchOption.AllDirectories).ToList().ToArray(), @"c:\test", true);
}
public void CopyTo(string[] files, string directory, bool overwriteIfExists)
{
    if (files == null)
    {
        throw new ArgumentNullException("files");
    }
    else if (!Directory.Exists(directory))
    {
        //throw Exception;
        Directory.CreateDirectory(directory);
    }
    int length = files.Length;
    for (int i = 0; i < length; i++)
    {
        File.Copy(files[i], directory, overwriteIfExists);
    }
}
If you will also need to recreate the sub-directories in the folder which you copied the files to, all you would need to do for that is use `Directory.CreateDirectory` along with the provided file name's directory name, with the replaced, `C:\temp\tempVideo\Storm.mp4\`, start:
///////////////
//CopyTo method
///////////////
int length = files.Length;
for (int i = 0; i < length; i++)
{
    string file = files[i];
    string name = Path.GetDirectoryName(file);
    if (!string.IsNullOrEmpty(name))
    {
        name = name.Replace(@"C:\temp\tempVideo\Storm.mp4\", directory);
        if (!Directory.Exists(name))
        {
            Directory.CreateDirectory(name);
        }
    }
    else
    {
        name = directory;
    }
    File.Copy(file, name, overwriteIfExists);
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.io.searchoption?view=netframework-4.8
  [2]: https://docs.microsoft.com/en-us/dotnet/api/system.io.file.copy?view=netframework-4.8#System_IO_File_Copy_System_String_System_String_System_Boolean_
