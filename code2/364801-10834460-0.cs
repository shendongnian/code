    If you will get the exception like "URI format is not supported" While Copying the xml file from     one directory to the another by using the following code.
    string path=System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
    DirectoryInfo dir=new DirectoryInfo(path+"\\App2");
    FileInfo[] Files=dir.GetFiles();
 
    then convert it into the URI like.
    string path =Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase); 
    URI uri = new URI(path); 
    string FileName = Path.Combine(uri.LocalPath, "\\App2"+file.Name);
    then use it to get the files.
