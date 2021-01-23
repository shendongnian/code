    /// <summary>
    /// Partner to Path.ChangeExtension. This function changes the base filename portion
    /// </summary>
    /// <param name="path"></param>
    /// <param name="newFilename"></param>
    /// <returns></returns>
    public static String ChangeFilename(String path, String newFilename)
    {
       String directoryName = Path.GetDirectoryName(path); //e.g. "C:\Temp\foo.dat" ==> "C:\Temp"
       //String oldFilename = Path.GetFileName(path); //e.g. "C:\Temp\foo.dat" ==> "foo.dat"
       //String filenameWithoutExtension = Path.GetFileNameWithoutExtension(path); //e.g. "C:\Temp\foo.dat" ==> "foo"
       String extension = Path.GetExtension(path); //e.g. "C:\Temp\foo.dat" ==> ".dat"
       //Reassemble as
       //    directoryName \ newFilename dotExtension
       return String.Format("{0}{1}{2}{3}",
             directoryName, 
             Path.DirectorySeparatorChar,
             newFilename,
             extension);
    }
