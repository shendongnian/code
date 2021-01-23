    using System;
    using System.IO;
    DirectoryInfo itunes = new DirectoryInfo("MyItunesPath");
    FileInfo[] itunesFiles = 
        itunes.GetFiles("*.*", SearchOption.AllDirectories);
