        using System.Collections;
        using System.Linq;
        using Microsoft.Office.Interop.Outlook;
        private MAPIFolder _mapiFolder;
        private MAPIFolder GetMyFolder(string path, IEnumerable folders)
        {
            if (!path.StartsWith(@"\\", StringComparison.Ordinal))
                return null;
            string pathRoot = GetFolderPathRoot(path);
            foreach (Folder folder in folders.Cast<Folder>().TakeWhile(
                folder => _mapiFolder == null).Select(
                    folder => new { folder, folderRoot = GetFolderPathRoot(folder.FolderPath) }).Where(
                        folder => folder.folderRoot == pathRoot).Select(folder => folder.folder))
            {
                if (folder.DefaultItemType == OlItemType.olAppointmentItem && folder.FolderPath == path)
                {
                    s_mapiFolder = folder;
                    break;
                }
                if (folder.Folders.Cast<Folder>().Any())
                    GetMapiFolder(false, folder.Folders, path);
            }
            return _mapiFolder;
        }
        private static string GetFolderPathRoot(string folderPath)
        {
            // Strip header directory seperator characters
            folderPath = folderPath.Remove(0, 2);
            // Find the index of a directory seperator character
            int index = folderPath.IndexOf(Path.DirectorySeparatorChar, 0);
            // Reconstruct the root path according to the index found
            return String.Format(@"\\{0}", index > 0 ? folderPath.Substring(0, index) : folderPath);
        }
