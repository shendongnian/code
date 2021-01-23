    using Nini.Config;
    IConfigSource source = new IniConfigSource("MyApp.ini");
    
    string fileName = source.Configs["Logging"].Get("File Name");
    int columns = source.Configs["Logging"].GetInt("MessageColumns");
    long fileSize = source.Configs["Logging"].GetLong("MaxFileSize");
