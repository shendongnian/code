  FileInfo[] fis = new DirectoryInfo(@"C:\foto's").GetFiles("*", SearchOption.TopDirectoryOnly);
  foreach(FileInfo fi in fis){
    //format a string representing the last write time, that is safe for filenames
    string datePart = fi.LastWriteTimeUtc.ToString("_yyyy-MM-dd HH;mm;ss"); //use ; for time because : is not allowed in path
    //break the name into parts based on the .
    string[] nameParts = fi.Name.Split('.');
    //add the date to the last-but-one part of the name
    if(nameParts.Length == 1) //there is no extension on the file
      nameParts[0] += datePart;
    else
      nameParts[nameParts.Length-1] += datePart;
    //join the name back together
    string newName = string.Join(".", nameParts);
    //move the file to the same directory but with a new name. Use Path.Combine to join directory and new file name into a full path
    fi.MoveTo(Path.Combine(fi.DirectoryName, newName));
  }
  Directory.Move(@"c:\foto's", @"c:\photos"); //fix two typos in your directory name ;)
