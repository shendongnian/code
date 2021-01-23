        using System.Collections;
        using System.Linq;
        using Microsoft.Office.Interop.Outlook;
        private MAPIFolder _mapiFolder;
        private const string RootFolderPath = @"\\Personal Folders";
        private MAPIFolder GetMyFolder(string path, IEnumerable folders)
        {
            string folderPath = System.IO.Path.Combine(RootFolderPath, path);
            foreach (Folder folder in folders.Cast<Folder>().Where(folder => folder.FolderPath.StartsWith(RootFolderPath)))
            {
                if (folder.DefaultItemType == OlItemType.olAppointmentItem && folder.FolderPath == folderPath)
                    _mapiFolder = folder;
                if (folder.Folders.Cast<Folder>().Any())
                    GetMapiFolder(path, folder.Folders);
            }
            return _mapiFolder;
        }
