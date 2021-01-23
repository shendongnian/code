    using Microsoft.SharePoint;
    public static void MassCheckIn()
    {
        using (SPSite oSharepointSite = new SPSite("http://sharepoint.com/YourTeamSite/"))
        {
            using (SPWeb oSharepointWeb = oSharepointSite.OpenWeb())
            {
                SPDocumentLibrary oSharepointDocs = (SPDocumentLibrary)oSharepointWeb.Lists["MyDocumentLibrary"];
                foreach (SPFile oSharepointFiles in oSharepointDocs.RootFolder.Files)
                {
                    if (oSharepointFiles.CheckOutType != SPFile.SPCheckOutType.None)
                    {
                        oSharepointFiles.CheckIn("Automatically Checked in by Your Application", SPCheckinType.MajorCheckIn);
                    }
                }
            }
        }
    }
    public static void MassCheckOut()
    {
        using (SPSite oSharepointSite = new SPSite("http://sharepoint.com/YourTeamSite/"))
        {
            using (SPWeb oSharepointWeb = oSharepointSite.OpenWeb())
            {
                SPDocumentLibrary oSharepointDocs = (SPDocumentLibrary)oSharepointWeb.Lists["MyDocumentLibrary"];
                foreach (SPFile oSharepointFiles in oSharepointDocs.RootFolder.Files)
                {
                    if (oSharepointFiles.CheckOutType == SPFile.SPCheckOutType.None)
                    {
                        oSharepointFiles.CheckOut();
                    }
                }
            }
        }
    }
    public static void RecursiveCopy(string sSourceFolder, string sDestinationFolder)
    {
        if (!Directory.Exists(sDestinationFolder))
            Directory.CreateDirectory(sDestinationFolder);
        string[] aFiles = Directory.GetFiles(sSourceFolder);
        foreach (string file in aFiles)
        {
            string sFileName = Path.GetFileName(file);
            string sDestination = Path.Combine(sDestinationFolder, sFileName);
            File.Copy(file, sDestination);
        }
        string[] aFolders = Directory.GetDirectories(sSourceFolder);
        foreach (string folder in aFolders)
        {
            string sFileName2 = Path.GetFileName(folder);
            string sDestination2 = Path.Combine(sDestinationFolder, sFileName2);
            RecursiveCopy(folder, sDestination2);
        }
    }
