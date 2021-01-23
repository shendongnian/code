    using System.IO;
    string[] files = { "" };
    if (Directory.Exists(path2Music)) {
        files = Directory.GetFiles(path2Music);
    }
