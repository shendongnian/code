using (ZipArchive archive = ZipFile.OpenRead(zipPath))
{
    Boolean isFolderExist = false;
    foreach (ZipArchiveEntry entry in archive.Entries) {
        if (entry.FullName.Contains("PDFsDir/")) {                       
            isFolderExist = true;
        }
    }
    if (isFolderExist) {
        Console.WriteLine("the folder which name is pictures exists in zip file");
        if(entry.FileName.Contains( "PDFsDir" )==true) {
            Console.WriteLine("File Exist");
        }
    } else {
        Console.WriteLine("the folder doesn't exist ");
    }
}
