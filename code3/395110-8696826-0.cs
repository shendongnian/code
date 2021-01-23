    using System.IO;
    using System.Windows.Forms;
    //blah blah
    string GetAppDir()
    {
        return Path.GetDirectoryName(Application.ExecutablePath);
    }
