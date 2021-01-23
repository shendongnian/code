    using System;
    using Microsoft.SharePoint;
    using System.IO;
    
    public static void RecursiveMassCheckIn()
    {
        using (SPSite oSharepointSite = new SPSite("http://sharepoint.com/MyTeamSite"))
        {
            using (SPWeb oSharepointWeb = oSharepointSite.OpenWeb())
            {
                SPDocumentLibrary oSharepointDocs = (SPDocumentLibrary)oSharepointWeb.Lists["MyDocumentLibrary"];
                int iFolderCount = oSharepointDocs.Folders.Count;
    
                //Check in whats on root
                MassCheckIn(oSharepointDocs.RootFolder);
    
                //Check in whats on subfolders
                for (int i = 0; i < iFolderCount; i++)
                {
                    MassCheckIn(oSharepointDocs.Folders[i].Folder);
                }
    
            }
        }
    }
    public static void MassCheckIn(SPFolder oSharepointFolder)
    {
        foreach (SPFile oSharepointFiles in oSharepointFolder.Files)
        {
            if (oSharepointFiles.CheckOutType != SPFile.SPCheckOutType.None)
            {
                oSharepointFiles.CheckIn("Programmatically Checked In");
            }
        }
    
    }
    
    public static void RecursiveCopy(string sSourceFolder, string sDestinationFolder)
    {
        if (!Directory.Exists(sDestinationFolder))
        {
            Directory.CreateDirectory(sDestinationFolder);
        }
        string[] aFiles = Directory.GetFiles(sSourceFolder);
        foreach (string sFile in aFiles)
        {
            string sFileName = Path.GetFileName(sFile);
            string sDestination = Path.Combine(sDestinationFolder, sFileName);
            File.Copy(sFile, sDestination);
        }
        string[] aFolders = Directory.GetDirectories(sSourceFolder);
        foreach (string sFolder in aFolders)
        {
            string sFileNameSub = Path.GetFileName(sFolder);
            string sDestinationSub = Path.Combine(sDestinationFolder, sFileNameSub);
            RecursiveCopy(sFolder, sDestinationSub);
        }
    }
