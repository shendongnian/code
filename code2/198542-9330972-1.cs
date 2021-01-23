        using System.Collections;
        using System.Linq;
        using Microsoft.Office.Interop.Outlook;
        private MAPIFolder _mapiFolder;
        private MAPIFolder GetMapiFolder(IEnumerable folders)
        {
            foreach (Folder folder in folders)
            {
                if (folder.DefaultItemType == OlItemType.olAppointmentItem && folder.Name == "CustomFolderName")
                    _mapiFolder = folder;
                if (folder.Folders.Cast<Folder>().Any())
                    GetMapiFolder(folder.Folders);
            }
            return _mapiFolder;
        }
